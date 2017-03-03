namespace StardewValleySave.Objects {
    public class Hat : Item {
        public int which;
        public string description;
        public string name;
        public bool skipHairDraw;
        public bool ignoreHairstyleOffset;

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

        public override int maximumStackSize()
        {
            return 1;
        }
    }
}
