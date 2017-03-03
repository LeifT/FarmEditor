using System.Collections.Generic;
using System.Xml.Serialization;
using StardewValleySave.TerrainFeatures;

namespace StardewValleySave.Locations {
    [XmlRoot(nameof(Woods))]
    public class Woods : GameLocation {
        public List<ResourceClump> stumps = new List<ResourceClump>();
        public bool hasUnlockedStatue;
        public bool hasFoundStardrop;
    }
}