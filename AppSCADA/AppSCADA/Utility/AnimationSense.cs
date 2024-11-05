using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Controls;

namespace AppSCADA.Utility
{
    public class AnimationSense
    {
        private TagInfo _Tag;

        public virtual TagInfo Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
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

        private ColorRGB _ColorWhenTagInRange = new ColorRGB();

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


        private int _PropertyValueWhenTagInRange;

        public int PropertyValueWhenTagInRange
        {
            get { return _PropertyValueWhenTagInRange; }
            set { _PropertyValueWhenTagInRange = value; }
        }

        private string _TextWhenTagInRange = "";

        public string TextWhenTagInRange
        {
            get { return _TextWhenTagInRange; }
            set { _TextWhenTagInRange = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public enum PropertyType
        {
            emIsVisible,
            emBackgroundColor,
            emHeight,
            emWidth,
            emText
        }
        public AnimationSense()
        {



        }

    }
}
