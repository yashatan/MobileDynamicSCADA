using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppSCADA.Utility
{
    public class ControlData
    {
        public string ControlType { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Rotation { get; set; }
        public string LabelText { get; set; }
        public string ImageSource { get; set; }
        public double FontSize { get; set; }
        public int ZIndex { get; set; }
        public ColorRGB BackgroundColor { get; set; }
        public ColorRGB ForegroundColor { get; set; }
        public ColorRGB Fill { get; set; }
        public List<AnimationSense> animationSenses { get; set; }
        public List<ItemEvent> ItemEvents { get; set; }
        public TagInfo TagConnection { get; set; }
        public ControlData()
        {

        }
    }

    public class ColorRGB
    {        //

        public byte B { get; set; }

        public byte G { get; set; }

        public byte R { get; set; }
        public ColorRGB()
        {
            R = 255;
            G = 255;
            B = 255;
        }
        public ColorRGB(Color color)
        {
            R = (byte)color.R;
            G = (byte)color.G;
            B = (byte)color.B;
        }
    }
}
