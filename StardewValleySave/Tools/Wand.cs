namespace StardewValleySave.Tools {
    public class Wand : Tool {
        public bool charged;

        public Wand() : base("Return Scepter", 0, 2, 2, "The golden handle quivers with raw potential. Hold this scepter to the sky and return home at will.", false, 0)
        {
            this.upgradeLevel = 0;
            base.CurrentParentTileIndex = this.indexOfMenuItemView;
            this.instantUse = true;
        }
    }
}
