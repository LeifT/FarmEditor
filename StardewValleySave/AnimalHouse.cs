using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StardewValleySave {
    public class AnimalHouse : GameLocation {
        public SerializableDictionary<long, FarmAnimal> animals = new SerializableDictionary<long, FarmAnimal>();
        public int animalLimit = 4;
        public List<long> animalsThatLiveHere = new List<long>();
        public Point incubatingEgg;
    }
}
