namespace StardewValleySave.Tools {
    public class WateringCan : Tool {
        public int waterCanMax = 40;
        private int waterLeft = 40;

        public override int UpgradeLevel {
            get {
                return this.upgradeLevel;
            }
            set {
                this.upgradeLevel = value;
                this.setNewTileIndexForUpgradeLevel();
            }
        }

        public int WaterLeft {
            get {
                return this.waterLeft;
            }
            set {
                this.waterLeft = value;
            }
        }

        public WateringCan() : base("Watering Can", 0, 273, 296, "Used to water crops. It can be refilled at any water source.", false, 0)
        {
            this.upgradeLevel = 0;
        }
    }
}
