using Microsoft.Xna.Framework;

namespace StardewValleySave.Objects {
    public class Wallpaper : Object {
        public Rectangle sourceRect;
        public bool isFloor;

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
    }
}
