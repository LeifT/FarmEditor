using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace StardewValleySave.TerrainFeatures
{
    public class Bush : LargeTerrainFeature {
        public int size;
        public int tileSheetOffset;
        public float health;
        public bool flipped;
        public bool townBush;
        public bool drawShadow = true;
    }
}
