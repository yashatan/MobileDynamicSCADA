using AppSCADA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace AppSCADA.Utility
{
    public class ControlDecoder
    {
        public ControlDecoder()
        {

        }

        public static View ConvertToControl(ControlData data)
        {
            View control;
            string contype = data.ControlType;
            switch (contype)
            {
                case "Image":
                    control = new Image();
                    control.HorizontalOptions = LayoutOptions.Start;
                    control.VerticalOptions = LayoutOptions.Start;
                    (control as Image).Aspect = Aspect.Fill;
                    break;
                case "TextBlock":
                    control = new Label();
                    break;
                case "Button":
                    control = new Button();
                    break;
                case "Ellipse":
                    control = new Ellipse();
                    break;
                case "Rectangle":
                    control = new Xamarin.Forms.Shapes.Rectangle();
                    break;
                case "TextBox":
                    control = new Entry();
                    break;
                default: throw new ArgumentException();
            }
            control.HeightRequest = data.Height;
            control.WidthRequest = data.Width;
            if (control.GetType() == typeof(Image))
            {
                if (data.ImageSource != null)
                {
                    var iamgeSourceArray = data.ImageSource.Split('/');
                    var imageFilename = iamgeSourceArray.Last();
                    (control as Image).Source = imageFilename;
                }
            }


            if (control.GetType().IsSubclassOf(typeof(Shape)))
            {
                (control as Shape).Fill = new SolidColorBrush( Color.FromRgb(data.BackgroundColor.R, data.BackgroundColor.G, data.BackgroundColor.B));
            }

            if (control.GetType() == typeof(Button))
            {
                (control as Button).Text = data.LabelText;
                (control as Button).FontSize = data.FontSize;
                (control as Button).TextColor = Color.FromRgb(data.ForegroundColor.R, data.ForegroundColor.G, data.ForegroundColor.B);
                (control as Button).BackgroundColor =  Color.FromRgb(data.BackgroundColor.R, data.BackgroundColor.G, data.BackgroundColor.B);
            }

            if (control.GetType() == typeof(Label))
            {
                (control as Label).TextColor = Color.FromRgb(data.ForegroundColor.R, data.ForegroundColor.G, data.ForegroundColor.B);
                (control as Label).Text = data.LabelText;
                (control as Label).FontSize = data.FontSize;
               // (control as Label).BackgroundColor = Color.FromRgb(data.BackgroundColor.R, data.BackgroundColor.G, data.BackgroundColor.B);
            }

            if (control.GetType() == typeof(Entry))
            {
                (control as Entry).TextColor = Color.FromRgb(data.ForegroundColor.R, data.ForegroundColor.G, data.ForegroundColor.B);
                (control as Entry).BackgroundColor = Color.FromRgb(data.BackgroundColor.R, data.BackgroundColor.G, data.BackgroundColor.B);
                (control as Entry).Keyboard = Keyboard.Numeric;
                (control as Entry).Text = data.LabelText;
                (control as Entry).FontSize = data.FontSize;
            }
            return control;
            //control.GetHashCode();
            //Tuple<View, List<AnimationSense>> tuple;

        }
    }
}
