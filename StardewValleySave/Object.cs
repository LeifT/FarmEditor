using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using StardewValleySave.Objects;

namespace StardewValleySave {
    [XmlInclude(typeof(Fence))]
    [XmlInclude(typeof(Boots))]
    [XmlInclude(typeof(Cask))]
    [XmlInclude(typeof(Chest))]
    [XmlInclude(typeof(ColoredObject))]
    [XmlInclude(typeof(CrabPot))]
    [XmlInclude(typeof(Door))]
    [XmlInclude(typeof(Hat))]
    [XmlInclude(typeof(Ring))]
    [XmlInclude(typeof(SpecialItem))]
    [XmlInclude(typeof(SwitchFloor))]
    [XmlInclude(typeof(TV))]
    [XmlInclude(typeof(Wallpaper))]
    [XmlInclude(typeof(WickedStatue))]
    [XmlInclude(typeof(Torch))]
    public class Object : Item {
        public Vector2 tileLocation;
        public int parentSheetIndex;
        public long owner;
        public string name;
        public string type;
        public bool canBeSetDown;
        public bool canBeGrabbed = true;
        public bool isHoedirt;
        public bool isSpawnedObject;
        public bool questItem;
        public bool isOn = true;
        public int fragility;
        public int price;
        public int edibility = -300;
        public int stack = 1;
        public int quality;
        public bool bigCraftable;
        public bool setOutdoors;
        public bool setIndoors;
        public bool readyForHarvest;
        public bool showNextIndex;
        public bool flipped;
        public bool hasBeenPickedUpByFarmer;
        public bool isRecipe;
        public bool isLamp;
        public Object heldObject;
        public int minutesUntilReady;
        public Rectangle boundingBox;
        public Vector2 scale;

        public Object() {}

        [XmlIgnore]
        public override int Stack
        {
            get
            {
                return Math.Max(0, this.stack);
            }
            set
            {
                this.stack = Math.Min(Math.Max(0, value), this.maximumStackSize());
            }
        }

        [XmlIgnore]
        public override string Name
        {
            get
            {
                return string.Concat(this.name, (this.isRecipe ? " Recipe" : ""));
            }
            set
            {
                this.name = value;
            }
        }

        public override int maximumStackSize() {
            if (this.category == -22) {
                return 1;
            }

            if (this.bigCraftable) {
                return -1;
            }

            return 999;
        }
    }
}
