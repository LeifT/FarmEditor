using System.Xml.Serialization;

namespace StardewValleySave {
    [XmlInclude(typeof(Object))]
    [XmlInclude(typeof(Tool))]
    public abstract class Item {
        public int specialVariable;
        public int category;
        public bool specialItem;
        public bool hasBeenInInventory;

        public abstract string Name
        {
            get;
            set;
        }

        public virtual int parentSheetIndex
        {
            get
            {
                if (!(this is Object))
                {
                    return -1;
                }
                return (this as Object).parentSheetIndex;
            }
        }

        public abstract int Stack
        {
            get;
            set;
        }

        public abstract int maximumStackSize();
    }
}
