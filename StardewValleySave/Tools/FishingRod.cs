namespace StardewValleySave.Tools {
    public class FishingRod : Tool {
        
        public FishingRod() : base("Fishing Rod", 0, 189, 8, "Use in the water to catch fish.", false, 0) {
            numAttachmentSlots = 2;
            attachments = new Object[numAttachmentSlots];
            indexOfMenuItemView = 8 + upgradeLevel;
        }

        public FishingRod(int upgradeLevel) : base("Fishing Rod", upgradeLevel, 189, 8, "Use in the water to catch fish.", false, 0)
        {
            this.numAttachmentSlots = 2;
            this.attachments = new Object[this.numAttachmentSlots];
            this.indexOfMenuItemView = 8 + upgradeLevel;
            this.upgradeLevel = upgradeLevel;
        }

        public override string Name {
            get {
                switch (this.upgradeLevel) {
                    case 0:
                        {
                            return "Bamboo Pole";
                        }
                    case 1:
                        {
                            return "Yew Rod";
                        }
                    case 2:
                        {
                            return "Fiberglass Rod";
                        }
                    case 3:
                        {
                            return "Iridium Rod";
                        }
                }
                return name;
            } 
            set {
                name = value;
            }
        }
    }
}
