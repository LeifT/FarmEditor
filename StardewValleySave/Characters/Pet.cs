namespace StardewValleySave.Characters {
    public class Pet : NPC {
        private int currentBehavior;
        public int friendshipTowardFarmer;

        public int CurrentBehavior
        {
            get
            {
                return this.currentBehavior;
            }
            set
            {
                this.currentBehavior = value;
                //this.initiateCurrentBehavior();
            }
        }
    }
}
