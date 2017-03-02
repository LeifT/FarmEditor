namespace FarmEditor.StardewValley
{
    public class GameObjecta {
        public int SpecialVariable { get; set; }
        public int Category { get; set; }
        public bool SpecialItem { get; set; }
        public bool HasBeenInInventory { get; set; }
        public string Name { get; set; }
        public int Stack { get; set; }
        public Vector2 TileLocation { get; set; }
        public int ParentSheetIndex { get; set; }
        public int Owner { get; set; }
        //public string Name { get; private set; }
        public ObjectType Type { get; set; }
        public bool CanBeSetDown { get; set; }
        public bool CanBeGrabbed { get; set; }
        public bool IsHoedirt { get; set; }
        public bool IsSpawnedObject { get; set; }
        public bool QuestItem { get; set; }
        public bool IsOn { get; set; }
        public int Fragility { get; set; }
        public int Price { get; set; }
        public int Edibility { get; set; }
        //public int stack { get; private set; }
        public int Quality { get; set; }
        public bool BigCraftable { get; set; }
        public bool SetOutdoors { get; set; }
        public bool SetIndoors { get; set; }
        public bool ReadyForHarvest { get; set; }
        public bool ShowNextIndex { get; set; }
        public bool Flipped { get; set; }
        public bool HasBeenPickedUpByFarmer { get; set; }
        public bool IsRecipe { get; set; }
        public bool IsLamp { get; set; }
        public int MinutesUntilReady { get; set; }
        public BoundingBox BoundingBox { get; set; }
        public Vector2 Scale { get; set; }
    }

    public enum ObjectType {
        Basic,
        Crafting,
        Asdf
    }
}
