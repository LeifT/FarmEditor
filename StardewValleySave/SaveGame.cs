using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using StardewValleySave.Characters;
using StardewValleySave.Locations;
using StardewValleySave.Monsters;
using StardewValleySave.Objects;
using StardewValleySave.Quests;
using StardewValleySave.TerrainFeatures;

namespace StardewValleySave {
    public class SaveGame {
        public static XmlSerializer serializer;
        public static XmlSerializer farmerSerializer;
        public static XmlSerializer locationSerializer;
        public Farmer player;
        public List<GameLocation> locations;
        public string currentSeason;
        public string samBandName;
        public string elliottBookName;
        public List<string> mailbox;
        public int dayOfMonth;
        public int year;
        public int farmerWallpaper;
        public int FarmerFloor;
        public int countdownToWedding;
        public int currentWallpaper;
        public int currentFloor;
        public int currentSongIndex;
        public Point incubatingEgg;
        public double chanceToRainTomorrow;
        public double dailyLuck;
        public ulong uniqueIDForThisGame;
        public bool weddingToday;
        public bool isRaining;
        public bool isDebrisWeather;
        public bool shippingTax;
        public bool bloomDay;
        public bool isLightning;
        public bool isSnowing;
        public bool shouldSpawnMonsters;
        public Stats stats;
        public static SaveGame loaded;
        public float musicVolume;
        public float soundVolume;
        public int[] cropsOfTheWeek;
        public Object dishOfTheDay;
        public long latestID;
        public Options options;
        public SerializableDictionary<int, MineInfo> mine_permanentMineChanges;
        public List<ResourceClump> mine_resourceClumps = new List<ResourceClump>();
        public int mine_mineLevel;
        public int mine_nextLevel;
        public int mine_lowestLevelReached;
        public int minecartHighScore;
        public int weatherForTomorrow;
        public int whichFarm;

        static SaveGame()
        {
            serializer = new XmlSerializer(typeof(SaveGame), new Type[] { typeof(Tool), typeof(GameLocation), typeof(Crow), typeof(Duggy), typeof(Bug), typeof(BigSlime), typeof(Fireball), typeof(Ghost), typeof(Child), typeof(Pet), typeof(Dog), typeof(Cat), typeof(Horse), typeof(GreenSlime), typeof(LavaCrab), typeof(RockCrab), typeof(ShadowGuy), typeof(SkeletonMage), typeof(SquidKid), typeof(Grub), typeof(Fly), typeof(DustSpirit), typeof(Quest), typeof(MetalHead), typeof(ShadowGirl), typeof(Monster), typeof(TerrainFeature) });
            farmerSerializer = new XmlSerializer(typeof(Farmer), new Type[] { typeof(Tool) });
            locationSerializer = new XmlSerializer(typeof(GameLocation), new Type[] { typeof(Tool), typeof(Crow), typeof(Duggy), typeof(Fireball), typeof(Ghost), typeof(GreenSlime), typeof(LavaCrab), typeof(RockCrab), typeof(ShadowGuy), typeof(SkeletonWarrior), typeof(Child), typeof(Pet), typeof(Dog), typeof(Cat), typeof(Horse), typeof(SquidKid), typeof(Grub), typeof(Fly), typeof(DustSpirit), typeof(Bug), typeof(BigSlime), typeof(BreakableContainer), typeof(MetalHead), typeof(ShadowGirl), typeof(Monster), typeof(TerrainFeature) });
        }

        public SaveGame() {
        }

        public void Load(string file) {
            SaveGame saveGame = new SaveGame();
           
            string[] folderPath = new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StardewValley", "Saves", file, file };
            string str = Path.Combine(folderPath);
            if (!File.Exists(str)) {
                str = string.Concat(str, ".xml");
                if (!File.Exists(str)) {
                    return;
                }
            }
          
            Stream stream = null;
            try {
                stream = File.Open(str, FileMode.Open);
                
            } catch (IOException) {
                stream?.Close();
                return;
            }

            loaded = (SaveGame)serializer.Deserialize(stream);
            stream.Close();
        }
    }
}