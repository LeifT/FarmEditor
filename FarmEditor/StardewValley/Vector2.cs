namespace FarmEditor.StardewValley {
    public class Vector2 {
        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;

                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
    }
}
