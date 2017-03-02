using System.Xml.Serialization;
using FarmEditor.StardewValley.GameLocations;

namespace FarmEditor.StardewValley {
    [XmlRoot("SaveGame")]
    public class SaveGame {

        [XmlElement("dayOfMonth")]
        public int DayOfMonth { get; set; }

        [XmlElement("year")]
        public int Year { get; set; }

        [XmlElement("farmerWallpaper")]
        public int FarmerWallpaper { get; set; }

        [XmlElement("FarmerFloor")]
        public int FarmerFloor { get; set; }
        
        [XmlArray("cropsOfTheWeek")]
        public int[] CropsOfTheWeek { get; set; }

        [XmlArray("locations")]
        [XmlArrayItem(Type = typeof(GameLocation)), XmlArrayItem(Type = typeof(FarmHouse)), 
            XmlArrayItem(Type = typeof(Farm)), XmlArrayItem(Type = typeof(FarmCave)),
            XmlArrayItem(Type = typeof(Town)), XmlArrayItem(Type = typeof(SeedShop)),
            XmlArrayItem(Type = typeof(Beach)), XmlArrayItem(Type = typeof(Mountain)),
            XmlArrayItem(Type = typeof(Forest)), XmlArrayItem(Type = typeof(WizardHouse)),
            XmlArrayItem(Type = typeof(BusStop)), XmlArrayItem(Type = typeof(Sewer)),
            XmlArrayItem(Type = typeof(Desert)), XmlArrayItem(Type = typeof(Club)),
            XmlArrayItem(Type = typeof(LibraryMuseum)), XmlArrayItem(Type = typeof(AdventureGuild)),
            XmlArrayItem(Type = typeof(Woods)), XmlArrayItem(Type = typeof(Railroad)),
            XmlArrayItem(Type = typeof(Summit)), XmlArrayItem(Type = typeof(BathHousePool)),
            XmlArrayItem(Type = typeof(CommunityCenter)), XmlArrayItem(Type = typeof(JojaMart)),
            XmlArrayItem(Type = typeof(Cellar))]
        public GameLocation[] Locations { get; set; }
    }

    [XmlRoot("item")]
    public class Item {
        [XmlElement("key")]
        public Key Key { get; set; }

        [XmlElement("value")]
        public Value Value { get; set; }
    }

    [XmlRoot("key")]
    public class Key {
        [XmlElement("Vector2")]
        public Vector2 Vec { get; set; }
    }

    [XmlRoot("value")]
    public class Value {
        [XmlElement("Object"), XmlElement(Type = typeof(Chest)), XmlElement(Type = typeof(Cask))]
        public GameObject GameObject { get; set; }
    }

    [XmlRoot(nameof(Chest))]
    public class Chest : GameObject {}
    
    [XmlRoot(nameof(Cask))]
    public class Cask : GameObject { }

    [XmlRoot("Object")]
    public class GameObject {
        [XmlElement("Name")]
        public string Name { get; set; }
    }

    [XmlRoot(nameof(GameLocation))]
    public class GameLocation {
        //public List<Character> Characters { get; set; }
        [XmlArray("objects"), XmlArrayItem("item")]
        public Item[] Items { get; set; }
        //public List<TerrainFeature> TerrainFeatures;
        //public List<Debris> Debris;
        [XmlElement("name")]
        public string Name { get; set; }
        //public WaterColor WaterColor;
        //public bool IsFarm;
        //public bool IsOutdoors;
        //public bool IgnoreDebrisWeather;
        //public bool IgnoreOutdoorLighting;
        //public bool IgnoreLights;
        //public bool TreatAsOutdoors;
        //public int NumberOfSpawnedObjectsOnMap;
    }
}