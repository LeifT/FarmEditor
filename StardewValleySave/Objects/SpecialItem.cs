namespace StardewValleySave.Objects {
    public class SpecialItem : Item {
        public string name;
        public int which;
        public int category;

        public override string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public override int Stack {
            get {
                return 1;
            }
            set { }
        }

        public override int maximumStackSize()
        {
            return 1;
        }
    }
}
