using System;
using System.Xml.Serialization;
using StardewValleySave.Tools;

namespace StardewValleySave {
    [XmlInclude(typeof(Axe))]
    [XmlInclude(typeof(FishingRod))]
    [XmlInclude(typeof(Hoe))]
    [XmlInclude(typeof(MagnifyingGlass))]
    [XmlInclude(typeof(MeleeWeapon))]
    [XmlInclude(typeof(MilkPail))]
    [XmlInclude(typeof(Pan))]
    [XmlInclude(typeof(Pickaxe))]
    [XmlInclude(typeof(Shears))]
    [XmlInclude(typeof(Slingshot))]
    [XmlInclude(typeof(Wand))]
    [XmlInclude(typeof(WateringCan))]
    public class Tool : Item {
        public Tool(string name, int upgradeLevel, int initialParentTileIndex, int indexOfMenuItemView, string description, bool stackable, int numAttachmentSlots = 0)
        {
            this.name = name;
            this.description = description;
            this.initialParentTileIndex = initialParentTileIndex;
            this.indexOfMenuItemView = indexOfMenuItemView;
            this.stackable = stackable;
            this.currentParentTileIndex = initialParentTileIndex;
            this.numAttachmentSlots = numAttachmentSlots;
            if (numAttachmentSlots > 0)
            {
                this.attachments = new Object[numAttachmentSlots];
            }
            this.category = -99;
        }

        public Tool()
        {
            this.category = -99;
        }

        public override string Name {
            get {
                switch (upgradeLevel) {
                    case 1:
                        {
                            return string.Concat("Copper ", this.name);
                        }
                    case 2:
                        {
                            return string.Concat("Steel ", this.name);
                        }
                    case 3:
                        {
                            return string.Concat("Gold ", this.name);
                        }
                    case 4:
                        {
                            return string.Concat("Iridium ", this.name);
                        }
                }
                return name;
            }
            set {
                name = value;
            }
        }

        public override int Stack {
            get {
                if (!stackable) {
                    return 1;
                }
                return ((Stackable)this).NumberInStack;
            }
            set {
                if (stackable) {
                    ((Stackable)this).Stack = Math.Min(Math.Max(0, value), maximumStackSize());
                }
            }
        }

        public string name;
        public string description;
        public int initialParentTileIndex;
        public int currentParentTileIndex;
        public int indexOfMenuItemView;
        public bool stackable;
        public bool instantUse;
        public int upgradeLevel;
        public int numAttachmentSlots;
        public Object[] attachments;

        public int CurrentParentTileIndex {
            get {
                return currentParentTileIndex;
            }
            set {
                currentParentTileIndex = value;
            }
        }

        public virtual int UpgradeLevel
        {
            get {
                return upgradeLevel;
            }
            set {
                upgradeLevel = value;
                this.setNewTileIndexForUpgradeLevel();
            }
        }

        public override int maximumStackSize() {
            if (stackable) {
                return 99;
            }
            return -1;
        }

        public virtual void setNewTileIndexForUpgradeLevel() {
            if (this is MeleeWeapon || this is MagnifyingGlass || this is MilkPail || this is Shears || this is Pan || this is Slingshot || this is Wand)
            {
                return;
            }
            int num = 21;
            if (this is FishingRod)
            {
                this.initialParentTileIndex = 8 + this.upgradeLevel;
                this.currentParentTileIndex = this.initialParentTileIndex;
                this.indexOfMenuItemView = this.initialParentTileIndex;
                return;
            }
            if (this is Axe)
            {
                num = 189;
            }
            else if (this is Hoe)
            {
                num = 21;
            }
            else if (this is Pickaxe)
            {
                num = 105;
            }
            else if (this is WateringCan)
            {
                num = 273;
            }
            num = num + this.upgradeLevel * 7;
            if (this.upgradeLevel > 2)
            {
                num = num + 21;
            }

            initialParentTileIndex = num;
            currentParentTileIndex = this.initialParentTileIndex;
            indexOfMenuItemView = this.initialParentTileIndex + (this is WateringCan ? 2 : 5) + 21;
        }

    }
}
