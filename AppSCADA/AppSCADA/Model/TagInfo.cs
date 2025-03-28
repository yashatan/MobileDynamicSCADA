//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppSCADA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class TagInfo : INotifyPropertyChanged
    {
        public TagInfo()
        {
            Type = TagType.eBool;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MemoryAddress { get; set; }
        public int DeviceAttach { get; set; }
        public enum TagType
        {
            eBool,
            eByte,
            eShort,
            eInt,
            eReal,
            eDouble
        }
        public TagType Type { get; set; }
        public byte BitPosition { get; set; }
        public string Value
        {
            get
            {
                if (Type == TagType.eBool)
                {
                    bool result = Convert.ToBoolean((Data >> BitPosition) & 0x1);
                    return result ? "1" : "0";
                }
                else if (Type == TagType.eByte)
                {
                    sbyte result = Convert.ToSByte(Data);
                    return result.ToString();
                }
                else if (Type == TagType.eShort)
                {
                    short result = Convert.ToInt16(Data);
                    return result.ToString();
                }
                else if (Type == TagType.eInt)
                {
                    int result = Convert.ToInt32(Data);
                    return result.ToString();
                }
                else if (Type == TagType.eReal)
                {
                    float result = BitConverter.ToSingle(BitConverter.GetBytes(Data), 0);
                    return result.ToString();
                }
                else if (Type == TagType.eDouble)
                {
                    byte[] bytes = BitConverter.GetBytes(Data);
                    double result = BitConverter.ToDouble(bytes, 0);
                    return result.ToString();
                }
                return "null";
            }
            set
            {
                if (Type == TagType.eBool)
                {
                    if (int.TryParse(value, out _))
                    {
                        Data = (Convert.ToInt64(value) << BitPosition);
                    }
                }
                else if (Type == TagType.eByte || Type == TagType.eShort || Type == TagType.eInt)
                {
                    if (int.TryParse(value, out _))
                    {
                        Data = Convert.ToInt64(value);
                    }
                }
                else if (Type == TagType.eReal)
                {
                    if (float.TryParse(value, out _))
                    {
                        float temp = Convert.ToSingle(value);
                        byte[] floatBytes = BitConverter.GetBytes(temp);
                        Data = BitConverter.ToInt64(new byte[] { floatBytes[0], floatBytes[1], floatBytes[2], floatBytes[3], 0, 0, 0, 0 }, 0);
                    }
                }
                else if (Type == TagType.eDouble)
                {
                    if (double.TryParse(value, out _))
                    {
                        double temp = Convert.ToDouble(value);
                        byte[] doubleBytes = BitConverter.GetBytes(temp);
                        Data = BitConverter.ToInt64(doubleBytes, 0);
                    }
                }
            }
        }
        private long data;
        public long Data { get => data; set { data = value; OnPropertyChanged(nameof(Value)); } }
        public virtual ConnectDevice ConnectDevice { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
