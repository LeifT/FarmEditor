using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StardewValleySave {
    public class Debris {
        public int chunkType;
        public int sizeOfSourceRectSquares = 8;
        public int itemQuality;
        public int chunkFinalYLevel;
        public int chunkFinalYTarget;
        public float timeSinceDoneBouncing;
        public float scale = 1f;
        public bool itemDebris;
        public bool floppingFish;
        public bool isFishable;
        public bool movingFinalYLevel;
        public bool visible = true;
        public Debris.DebrisType debrisType;
        public string debrisMessage = "";
        public Color nonSpriteChunkColor = Color.White;
        public Color chunksColor;
        public Item item;
        public int uniqueID;
        public Character toHover;

        private List<Chunk> chunks = new List<Chunk>();

        public List<Chunk> Chunks {
            get {
                return chunks;
            }
        }

        public enum DebrisType {
            CHUNKS,
            LETTERS,
            SQUARES,
            ARCHAEOLOGY,
            OBJECT,
            SPRITECHUNKS,
            RESOURCE,
            NUMBERS
        }
    }
}
