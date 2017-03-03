using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using StardewValleySave.Tools;

namespace StardewValleySave.Objects {
    [XmlInclude(typeof(MeleeWeapon))]
    public class Chest : Object {
        public int currentLidFrame = 501;
        public int frameCounter = -1;
        public int coins;
        public List<Item> items = new List<Item>();
        public string chestType = "";
        public Color tint = Color.White;
        public Color playerChoiceColor = Color.Black;
        public bool playerChest;
        public bool fridge;
        public bool giftbox;
    }
}
