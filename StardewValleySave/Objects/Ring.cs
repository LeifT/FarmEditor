namespace StardewValleySave.Objects {
    public class Ring : Item {
        public string description;
        public string name;
        public int price;
        public int indexInTileSheet;
        public int uniqueID;

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public override int parentSheetIndex
        {
            get
            {
                return this.indexInTileSheet;
            }
        }

        public override int Stack
        {
            get
            {
                return 1;
            }
            set
            {
            }
        }

        public Ring()
        {
        }

        public override int maximumStackSize()
        {
            return 1;
        }
    }
}
