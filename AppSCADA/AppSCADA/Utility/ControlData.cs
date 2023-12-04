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
        public double FontSize { get; set; }
        public string ImageSource { get; set; }
        public ColorRGB BackgroundColor { get; set; }
        public ColorRGB ForegroundColor { get; set; }
        public List<AnimationSense> animationSenses { get; set; }
        public List<ItemEvent> ItemEvents { get; set; }
        public string TagConnection {  get; set; }
        public ColorRGB Fill { get; set; }
        public ControlData()
        {

        }
    }

    public class ColorRGB
    {        //

        public int B { get; set; }

        public int G { get; set; }

        public int R { get; set; }

    }
}
