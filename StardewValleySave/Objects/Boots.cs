namespace StardewValleySave.Objects {
    public class Boots : Item {
        public int defenseBonus;

        public int immunityBonus;

        public int indexInTileSheet;

        public int price;

        public int indexInColorSheet;

        public string description;

        public string name;

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

        public Boots()
        {
            this.category = -97;
        }

        public override int maximumStackSize()
        {
            return -1;
        }
    }
}
