using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Controls;

namespace AppSCADA.Utility
{
    public class AnimationSense
    {
        private string _Tagname;

        public string Tagname
        {
            get { return _Tagname; }
            set { _Tagname = value; }
        }
        private string _TextWhenTagInRange;

        public string TextWhenTagInRange
        {
            get { return _TextWhenTagInRange; }
            set { _TextWhenTagInRange = value; }
        }

        public enum PropertyType
        {
            emIsVisible,
            emBackgroundcColor,
            emHeight,
            emWidth,
            emText
        }
        private PropertyType _PropertyNeedChange;

        public PropertyType PropertyNeedChange
        {
            get { return _PropertyNeedChange; }
            set { _PropertyNeedChange = value; }
        }

        private int _Tagvaluemin;

        public int Tagvaluemin
        {
            get { return _Tagvaluemin; }
            set { _Tagvaluemin = value; }
        }

        private int _Tagvaluemax;

        public int Tagvaluemax
        {
            get { return _Tagvaluemax; }
            set { _Tagvaluemax = value; }
        }

        private ColorRGB _ColorWhenTagInRange;

        public ColorRGB ColorWhenTagInRange
        {
            get { return _ColorWhenTagInRange; }
            set { _ColorWhenTagInRange = value; }
        }

        private bool _PropertyBoolValueWhenTagInRange;

        public bool PropertyBoolValueWhenTagInRange
        {
            get { return _PropertyBoolValueWhenTagInRange; }
            set { _PropertyBoolValueWhenTagInRange = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int _PropertyValueWhenTagInRange;

        public int PropertyValueWhenTagInRange
        {
            get { return _PropertyValueWhenTagInRange; }
            set { _PropertyValueWhenTagInRange = value; }
        }


    }
}
