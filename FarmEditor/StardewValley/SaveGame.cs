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

        //[XmlElement("locations")]
        //public int Locations { get; set; }

        [XmlArray("cropsOfTheWeek")]
        public int[] CropsOfTheWeek { get; set; }

        [XmlArray("locations")]
        [XmlArrayItem(Type = typeof(GameLocation)), 
            XmlArrayItem(Type = typeof(FarmHouse)), 
            XmlArrayItem(Type = typeof(Farm)),
            XmlArrayItem(Type = typeof(FarmCave)),
            XmlArrayItem(Type = typeof(Town)),
            XmlArrayItem(Type = typeof(SeedShop)),
            XmlArrayItem(Type = typeof(Beach)),
            XmlArrayItem(Type = typeof(Mountain)),
            XmlArrayItem(Type = typeof(Forest)),
            XmlArrayItem(Type = typeof(WizardHouse)),
            XmlArrayItem(Type = typeof(BusStop)),
            XmlArrayItem(Type = typeof(Sewer)),
            XmlArrayItem(Type = typeof(Desert)),
            XmlArrayItem(Type = typeof(Club)),
            XmlArrayItem(Type = typeof(LibraryMuseum)),
            XmlArrayItem(Type = typeof(AdventureGuild)),
            XmlArrayItem(Type = typeof(Woods)),
            XmlArrayItem(Type = typeof(Railroad)),
            XmlArrayItem(Type = typeof(Summit)),
            XmlArrayItem(Type = typeof(BathHousePool)),
            XmlArrayItem(Type = typeof(CommunityCenter)),
            XmlArrayItem(Type = typeof(JojaMart)),
            XmlArrayItem(Type = typeof(Cellar))]

        public GameLocation[] Locations { get; set; }

        //public SaveGame(string filename) {
        //    Load(ReadXml(filename));
        //}

        //private void Load(XDocument xDoc) {
        //    //var xSave = xDoc.Element("SaveGame");

        //    //Locations = new List<GameLocation>();

        //    //foreach (var xElement in xSave.Element("locations").Elements()) {
        //    //    //Console.WriteLine(xElement);

        //    //    GameLocation location = new GameLocation();

        //    //    location.Name = (string) xElement.Element("name");

        //    //    if (location.Name.Equals("Farm")) {
        //    //        foreach (var variable in xElement.Element("objects").Elements("item")) {
        //    //            var xGameObject = variable.Element("value").Element("Object");

        //    //            GameObject gameObject = new GameObject();
        //    //            gameObject.Name = (string) xGameObject.Element("Name");


        //    //        }

        //    //        Locations.Add(location);
        //    //    }
        //    //}
        //}
    }

    [XmlRoot("GameLocation")]
    public class GameLocation {
        //public List<Character> Characters { get; set; }
        //public List<GameObject> GameObjects;
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