using Microsoft.Xna.Framework;

namespace StardewValleySave.Objects {
    public class Furniture : Object {
        public int price;
        public int furniture_type;
        public int rotations;
        public int currentRotation;
        public Rectangle sourceRect;
        public Rectangle defaultSourceRect;
        public Rectangle defaultBoundingBox;
        public string description;
        public bool flipped;
        public bool drawHeldObjectLow;

        public override string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
    }
}
