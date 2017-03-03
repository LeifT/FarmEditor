﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValleySave.Objects;
using StardewValleySave.Quests;

namespace StardewValleySave {
    public class Farmer : Character {
        public List<Quest> questLog = new List<Quest>();
        public List<int> professions = new List<int>();
        public List<Point> newLevels = new List<Point>();
        public int[] experiencePoints = new int[6];
        public List<Item> items;
        public List<int> dialogueQuestionsAnswered = new List<int>();
        public List<string> furnitureOwned = new List<string>();

        public SerializableDictionary<string, int> cookingRecipes = new SerializableDictionary<string, int>();
        public SerializableDictionary<string, int> craftingRecipes = new SerializableDictionary<string, int>();
        public SerializableDictionary<string, int> activeDialogueEvents = new SerializableDictionary<string, int>();

        public List<int> eventsSeen = new List<int>();
        public List<string> songsHeard = new List<string>();
        public List<int> achievements = new List<int>();
        public List<int> specialItems = new List<int>();
        public List<int> specialBigCraftables = new List<int>();
        public List<string> mailReceived = new List<string>();
        public List<string> mailForTomorrow = new List<string>();
        public List<string> blueprints = new List<string>();
        public List<CoopDweller> coopDwellers = new List<CoopDweller>();
        public List<BarnDweller> barnDwellers = new List<BarnDweller>();
        public Tool[] toolBox = new Tool[30];
        public Object[] cupboard = new Object[30];
        public string farmName = "";
        public string favoriteThing = "";
        public bool catPerson = true;
        public Vector2 mostRecentBed;
        public int shirt;
        public int hair;
        public int skin;
        public int accessory = -1;
        public int facialHair = -1;
        public Color hairstyleColor;
        public Color pantsColor;
        public Color newEyeColor;
        public Hat hat;
        public Boots boots;
        public Ring leftRing;
        public Ring rightRing;
        public int deepestMineLevel;
        public int woodPieces;
        public int stonePieces;
        public int copperPieces;
        public int ironPieces;
        public int coalPieces;
        public int goldPieces;
        public int iridiumPieces;
        public int quartzPieces;
        public int caveChoice;
        public int feed;
        public int farmingLevel;
        public int miningLevel;
        public int combatLevel;
        public int foragingLevel;
        public int fishingLevel;
        public int luckLevel;
        public int newSkillPointsToSpend;
        public int addedFarmingLevel;
        public int addedMiningLevel;
        public int addedCombatLevel;
        public int addedForagingLevel;
        public int addedFishingLevel;
        public int addedLuckLevel;
        public int maxStamina = 270;
        public int maxItems = 12;
        public float stamina = 270f;
        public int resilience;
        public int attack;
        public int immunity;
        public float attackIncreaseModifier;
        public float knockbackModifier;
        public float weaponSpeedModifier;
        public float critChanceModifier;
        public float critPowerModifier;
        public float weaponPrecisionModifier;
        public int money = 500;
        public int clubCoins;
        public uint totalMoneyEarned;
        public uint millisecondsPlayed;
        public Tool toolBeingUpgraded;
        public int daysLeftForToolUpgrade;
        public int houseUpgradeLevel;
        public int daysUntilHouseUpgrade = -1;
        public int coopUpgradeLevel;
        public int barnUpgradeLevel;
        public bool hasGreenhouse;
        public bool hasRustyKey;
        public bool hasSkullKey;
        public bool hasUnlockedSkullDoor;
        public bool hasDarkTalisman;
        public bool hasMagicInk;
        public bool showChestColorPicker = true;
        public int magneticRadius;
        public int temporaryInvincibilityTimer;
        public int health = 100;
        public int maxHealth = 100;
        public int timesReachedMineBottom;
        public bool isMale = true;
        public bool hasBusTicket;
        public bool stardewHero;
        public bool hasClubCard;
        public bool hasSpecialCharm;
        public bool canUnderstandDwarves;
        public SerializableDictionary<int, int> basicShipped;
        public SerializableDictionary<int, int> mineralsFound;
        public SerializableDictionary<int, int> recipesCooked;
        public SerializableDictionary<int, int[]> archaeologyFound;
        public SerializableDictionary<int, int[]> fishCaught;
        public SerializableDictionary<string, int[]> friendships;
        public BuildingUpgrade currentUpgrade;
        public string spouse;
        public string dateStringForSaveGame;
        public int overallsColor;
        public int shirtColor;
        public int skinColor;
        public int hairColor;
        public int eyeColor;
    }
}
