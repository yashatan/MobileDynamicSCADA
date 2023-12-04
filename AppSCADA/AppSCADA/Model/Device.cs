using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using EasyModbus;
using AppSCADA.Mvvm;
using S7.Net;
using System.Threading.Tasks;
using System.IO.Ports;
using Xamarin.Forms;

namespace AppSCADA.Model
{
    public class Device : BindableBase
    {
        //For connection
        public ConnectionStates ConnectionState { get; private set; }
        private string name;
        // private S7Client thePLC;
        public Plc thePLC;
        private volatile object _locker = new object();
        private int level;
        private bool highStatus;
        private bool lowStatus;
        private Motor motor_1;
        private Motor motor_2;
        private Motor motor_3;
        //FrameWorkElement a;
        //ContentControl
        //AbsoluteLayout
        public Motor_Data Motor_1_Data = new Motor_Data();
        public Motor_Data Motor_2_Data = new Motor_Data();
        public Motor_Data Motor_3_Data = new Motor_Data();
        System.Timers.Timer UpdateTimer;

        private string IP;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public int Level { get => level; set { level = value; OnPropertyChanged(); } }
        public bool HighStatus { get => highStatus; set { highStatus = value; OnPropertyChanged(); } }
        public bool LowStatus { get => lowStatus; set { lowStatus = value; OnPropertyChanged(); } }

        public Motor Motor_1 { get => motor_1; set { motor_1 = value; OnPropertyChanged(); } }
        public Motor Motor_2 { get => motor_2; set { motor_2 = value; OnPropertyChanged(); } }
        public Motor Motor_3 { get => motor_3; set { motor_3 = value; OnPropertyChanged(); } }

        ModbusClient modbusClient;

        public Device(string name, string ip)
        {
            Motor_1 = new Motor("Motor_1");
            Motor_2 = new Motor("Motor_2");
            Motor_3 = new Motor("Motor_3");
            IP = ip;
            //thePLC = new S7Client();
            thePLC = new Plc(CpuType.S71500, IP, 0, 1);

            Connect(ip, 0, 1);
        }

        private void UpdateTags(object sender, ElapsedEventArgs e)
        {
            try
            {
                UpdateTimer.Stop();
                // ScanTime = DateTime.Now - _lastScanTime;
                lock (_locker)
                {
                    object ob1 = thePLC.Read("DB1.DBX2.4");
                    Motor_1.Runfeedback = Convert.ToBoolean(ob1);
                    object ob2 = thePLC.Read("DB2.DBX2.4");
                    Motor_2.Runfeedback = Convert.ToBoolean(ob2);
                    object ob3 = thePLC.Read("DB3.DBX2.4");
                    Motor_3.Runfeedback = Convert.ToBoolean(ob3);
                    //ModbusReadClass(motor_1, 100);
                    //ModbusReadClass(motor_2, 104);
                    //ModbusReadClass(motor_3, 108);
                    readStatus();
                    Level = readLevel();
                }
            }
            finally
            {
                UpdateTimer.Start();
            }
        }

        private int readLevel()
        {
            ////Task<object> readLevelTask = thePLC.Read("MW100");
            object ob = thePLC.Read("MW100");
            int temp = Convert.ToInt16(ob);
            //int temp;
            //temp = ModbusReadRegister(114, 1);
            return temp;
        }
        int ModbusReadRegister(int start_add, int quantity)
        {
            int[] temp;
            temp = modbusClient.ReadHoldingRegisters(start_add, quantity);
            return temp[0];
        }
        void ModbusReadClass(Motor motor_data, int start_add)
        {
            int[] value = modbusClient.ReadHoldingRegisters(start_add, 4);
            motor_data.Mode = (ushort)value[0];
            motor_data.Start = Convert.ToBoolean(value[1] & 0x1);
            motor_data.Stop = Convert.ToBoolean(value[1] >> 8 & 0x1);//get 16 higher bit to get value of Stop
            motor_data.Runfeedback = Convert.ToBoolean(value[2] & 0x1);
            //motor_data.Reset = Convert.ToBoolean(value[2] >> 8 & 0x1);//get 16 higher bit to get value of Reset
            motor_data.Fault = Convert.ToBoolean(value[3]);
        }
        private void UpdateMotor(Motor motor, Motor_Data motor_data)
        {
            motor.Start = motor_data.Start;
            motor.Runfeedback = motor_data.Runfeedback;
            //int DBnumber;
            //switch (motor.Name)
            //{
            //    case "Motor1":
            //        DBnumber = 1;
            //        break;
            //    case "Motor2":
            //        DBnumber = 2;
            //        break;
            //    case "Motor3":
            //        DBnumber = 3;
            //        break;
            //    default:
            //        DBnumber = 1;
            //        break;
            //}

            //lock (_locker)
            //{
            //    var buffer = new byte[1];
            //    int result = thePLC.DBRead(DBnumber, 2, buffer.Length, buffer);
            //    if (result == 0)
            //    {
            //        //motor.Mode = (ushort)buffer[0];
            //        motor.Start = S7.GetBitAt(buffer, 0, 0);
            //        motor.Stop = S7.GetBitAt(buffer, 0, 1);
            //        motor.Runfeedback = S7.GetBitAt(buffer, 0, 4);
            //       // motor.Fault = S7.GetBitAt(buffer, 4, 1);
            //    }
            //    else
            //    {
            //        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Read error: " + thePLC.ErrorText(result));
            //    }
            //}

        }

        public void Connect(string ipAddress, int rack, int slot)
        {
            try
            {
                //Task a = thePLC.OpenAsync();
                //a.Await();
                thePLC.Open();
                Console.WriteLine($"Connect to the PLC {Name} {IP} succesfully");
                UpdateTimer = new System.Timers.Timer(500);
                UpdateTimer.Elapsed += UpdateTags;
                //UpdateTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can not connect to the PLC {IP}: {ex.Message}");
                throw;
            }
            //try
            //{
            //modbusClient = new EasyModbus.ModbusClient(ipAddress, 502);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusClient.Connect();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //UpdateTimer = new System.Timers.Timer(500);
            //UpdateTimer.Elapsed += UpdateTags;
            //UpdateTimer.Start();
        }



        public void Disconnect()
        {
            thePLC.Close();
        }

        //private int thePLC.Write(string address, bool value)
        //{
        //    var strings = address.Split('.');
        //    int db = Convert.ToInt32(strings[0].Replace("DB", ""));
        //    int pos = Convert.ToInt32(strings[1].Replace("DBX", ""));
        //    int bit = Convert.ToInt32(strings[2]);
        //    return thePLC.Write(db, pos, bit, value);
        //}

        //private int thePLC.Write(int db, int pos, int bit, bool value)
        //{
        //    //lock (_locker)
        //    //{
        //    //    var buffer = new byte[1];
        //    //    //S7.SetBitAt(ref buffer, 0, bit, value);
        //    //    return thePLC.WriteArea(S7Consts.S7AreaDB, db, pos + bit, buffer.Length, S7Consts.S7WLBit, buffer);
        //    //}
        //}

        public void WriteAuto(bool value, string tag)
        {
            lock (_locker)
            {
                switch (tag)
                {
                    case "Start":
                        thePLC.WriteAsync("DB6.DBX0.0", value);
                        break;
                    case "Stop":
                        thePLC.WriteAsync("DB6.DBX0.1", value);
                        break;
                }
            }
        }
        public void Write(object value, string tagname)
        {
            lock (_locker)
            {
                string[] s = tagname.Split('.');
                switch (s[0])
                {
                    case "Motor_1":
                        switch (s[1])
                        {
                            case "Mode":
                                thePLC.WriteAsync("DB1.DBW0", value);
                                break;
                            case "Start":
                                thePLC.Write("DB1.DBX2.0", value);
                                break;
                            case "Stop":
                                thePLC.Write("DB1.DBX2.1", value);
                                break;
                            case "Reset":
                                thePLC.WriteAsync("DB1.DBX2.4", value);
                                break;

                        }
                        break;
                    case "Motor_2":
                        switch (s[1])
                        {
                            case "Mode":
                                thePLC.WriteAsync("DB2.DBW0", value);
                                break;
                            case "Start":
                                thePLC.Write("DB2.DBX2.0", value);
                                break;
                            case "Stop":
                                thePLC.Write("DB2.DBX2.1", value);
                                break;
                            case "Reset":
                                thePLC.WriteAsync("DB2.DBX2.4", value);
                                break;

                        }
                        break;
                    case "Motor_3":
                        switch (s[1])
                        {
                            case "Mode":
                                thePLC.WriteAsync("DB3.DBW0", value);
                                break;
                            case "Start":
                                thePLC.Write("DB3.DBX2.0", value);
                                break;
                            case "Stop":
                                thePLC.Write("DB3.DBX2.1", value);
                                break;
                            case "Reset":
                                thePLC.WriteAsync("DB3.DBX2.4", value);
                                break;
                        }
                        break;
                }
                //switch (s[0])
                //{
                //    case "Motor_1":
                //        switch (s[1])
                //        {
                //            case "Mode":
                //                ModbusWriteRegister(100, Convert.ToInt32(value));
                //                break;
                //            case "Start":
                //                ModbusWriteRegister(101, Convert.ToInt32(value));
                //                break;
                //            case "Stop":
                //                ModbusWriteRegister(101, (Convert.ToInt32(value)) << 8);
                //                break;
                //            case "Reset":
                //                ModbusWriteRegister(102, (Convert.ToInt32(value)) << 8);
                //                break;

                //        }
                //        break;
                //    case "Motor_2":
                //        switch (s[1])
                //        {
                //            case "Mode":
                //                ModbusWriteRegister(104, Convert.ToInt32(value));
                //                break;
                //            case "Start":
                //                ModbusWriteRegister(105, Convert.ToInt32(value));
                //                break;
                //            case "Stop":
                //                ModbusWriteRegister(105, (Convert.ToInt32(value)) << 8);
                //                break;
                //            case "Reset":
                //                ModbusWriteRegister(106, (Convert.ToInt32(value)) << 8);
                //                break;

                //        }
                //        break;
                //    case "Motor_3":
                //        switch (s[1])
                //        {
                //            case "Mode":
                //                ModbusWriteRegister(108, Convert.ToInt32(value));
                //                break;
                //            case "Start":
                //                ModbusWriteRegister(109, Convert.ToInt32(value));

                //                break;
                //            case "Stop":
                //                ModbusWriteRegister(109, (Convert.ToInt32(value)) << 8);

                //                break;
                //            case "Reset":
                //                ModbusWriteRegister(110, (Convert.ToInt32(value)) << 8);
                //                break;
                //        }
                //        break;
                //}
            }



        }
        void ModbusWriteRegister(int start_add, int value)
        {
            modbusClient.WriteSingleRegister(start_add, value);
        }
        public void readStatus()
        {
            object ob1 = thePLC.Read("DB6.DBX0.2");
            HighStatus = Convert.ToBoolean(ob1);
            object ob2 = thePLC.Read("DB6.DBX0.3");
            LowStatus = Convert.ToBoolean(ob2);
            //int temp;
            //temp = ModbusReadRegister(113, 1);
            //HighStatus = Convert.ToBoolean(temp & 0xFF);
            //LowStatus = Convert.ToBoolean(temp >> 8 & 0xFF);
        }

    }
    public class Motor_Data
    {
        public ushort Mode { get; set; }
        public bool Start { get; set; }
        public bool Stop { get; set; }
        public bool RunCondition { get; set; }
        public bool StopCondition { get; set; }
        public bool Runfeedback { get; set; }
        public bool Reset { get; set; }
        public byte Output { get; set; }
        public bool cmd { get; set; }
        public bool Fault { get; set; }
    }
    public enum ConnectionStates
    {
        Offline,
        Connecting,
        Online
    }
}
