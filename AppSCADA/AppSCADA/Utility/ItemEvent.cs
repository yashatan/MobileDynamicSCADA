using System;
using System.Collections.Generic;
using System.Text;

namespace AppSCADA.Utility
{
    public class ItemEvent
    {
        public ItemEvent()
        {

        }

        public enum ItemEventType
        {
            emClick,
            emPress,
            emRelease
        }

        public enum ItemActiontype
        {
            emSetbit,
            emResetBit
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public ItemEventType EventType { get; set; }
        public ItemActiontype ActionType { get; set; }
        public virtual TagInfo Tag { get; set; }

    }
}
