namespace StardewValleySave {
    public class Stats {
        public uint seedsSown;
        public uint itemsShipped;
        public uint itemsCooked;
        public uint itemsCrafted;
        public uint chickenEggsLayed;
        public uint duckEggsLayed;
        public uint cowMilkProduced;
        public uint goatMilkProduced;
        public uint rabbitWoolProduced;
        public uint sheepWoolProduced;
        public uint cheeseMade;
        public uint goatCheeseMade;
        public uint trufflesFound;
        public uint stoneGathered;
        public uint rocksCrushed;
        public uint dirtHoed;
        public uint giftsGiven;
        public uint timesUnconscious;
        public uint averageBedtime;
        public uint timesFished;
        public uint fishCaught;
        public uint bouldersCracked;
        public uint stumpsChopped;
        public uint stepsTaken;
        public uint monstersKilled;
        public uint diamondsFound;
        public uint prismaticShardsFound;
        public uint otherPreciousGemsFound;
        public uint caveCarrotsFound;
        public uint copperFound;
        public uint ironFound;
        public uint coalFound;
        public uint coinsFound;
        public uint goldFound;
        public uint iridiumFound;
        public uint barsSmelted;
        public uint beveragesMade;
        public uint preservesMade;
        public uint piecesOfTrashRecycled;
        public uint mysticStonesCrushed;
        public uint daysPlayed;
        public uint weedsEliminated;
        public uint sticksChopped;
        public uint notesFound;
        public uint questsCompleted;
        public uint starLevelCropsShipped;
        public uint cropsShipped;
        public uint slimesKilled;
        public uint geodesCracked;
        public SerializableDictionary<string, int> specificMonstersKilled = new SerializableDictionary<string, int>();

        public uint AverageBedtime
        {
            get
            {
                return this.averageBedtime;
            }
            set
            {
                averageBedtime = (averageBedtime * (daysPlayed - 1) + value) / daysPlayed;
            }
        }

        public uint BarsSmelted
        {
            get
            {
                return this.barsSmelted;
            }
            set
            {
                this.barsSmelted = value;
            }
        }

        public uint BeveragesMade
        {
            get
            {
                return this.beveragesMade;
            }
            set
            {
                this.beveragesMade = value;
            }
        }

        public uint BouldersCracked
        {
            get
            {
                return this.bouldersCracked;
            }
            set
            {
                this.bouldersCracked = value;
            }
        }

        public uint CaveCarrotsFound
        {
            get
            {
                return this.caveCarrotsFound;
            }
            set
            {
                this.caveCarrotsFound = value;
            }
        }

        public uint CheeseMade
        {
            get
            {
                return this.cheeseMade;
            }
            set
            {
                this.cheeseMade = value;
            }
        }

        public uint ChickenEggsLayed
        {
            get
            {
                return this.chickenEggsLayed;
            }
            set
            {
                this.chickenEggsLayed = value;
            }
        }

        public uint CoalFound
        {
            get
            {
                return this.coalFound;
            }
            set
            {
                this.coalFound = value;
            }
        }

        public uint CoinsFound
        {
            get
            {
                return this.coinsFound;
            }
            set
            {
                this.coinsFound = value;
            }
        }

        public uint CopperFound
        {
            get
            {
                return this.copperFound;
            }
            set
            {
                this.copperFound = value;
            }
        }

        public uint CowMilkProduced
        {
            get
            {
                return this.cowMilkProduced;
            }
            set
            {
                this.cowMilkProduced = value;
            }
        }

        public uint CropsShipped
        {
            get
            {
                return this.cropsShipped;
            }
            set
            {
                this.cropsShipped = value;
            }
        }

        public uint DaysPlayed
        {
            get
            {
                return this.daysPlayed;
            }
            set
            {
                this.daysPlayed = value;
            }
        }

        public uint DiamondsFound
        {
            get
            {
                return this.diamondsFound;
            }
            set
            {
                this.diamondsFound = value;
            }
        }

        public uint DirtHoed
        {
            get
            {
                return this.dirtHoed;
            }
            set
            {
                this.dirtHoed = value;
            }
        }

        public uint DuckEggsLayed
        {
            get
            {
                return this.duckEggsLayed;
            }
            set
            {
                this.duckEggsLayed = value;
            }
        }

        public uint FishCaught
        {
            get
            {
                return this.fishCaught;
            }
            set
            {
                this.fishCaught = value;
            }
        }

        public uint GeodesCracked
        {
            get
            {
                return this.geodesCracked;
            }
            set
            {
                this.geodesCracked = value;
            }
        }

        public uint GiftsGiven
        {
            get
            {
                return this.giftsGiven;
            }
            set
            {
                this.giftsGiven = value;
            }
        }

        public uint GoatCheeseMade
        {
            get
            {
                return this.goatCheeseMade;
            }
            set
            {
                this.goatCheeseMade = value;
            }
        }

        public uint GoatMilkProduced
        {
            get
            {
                return this.goatMilkProduced;
            }
            set
            {
                this.goatMilkProduced = value;
            }
        }

        public uint GoldFound
        {
            get
            {
                return this.goldFound;
            }
            set
            {
                this.goldFound = value;
            }
        }

        public uint IridiumFound
        {
            get
            {
                return this.iridiumFound;
            }
            set
            {
                this.iridiumFound = value;
            }
        }

        public uint IronFound
        {
            get
            {
                return this.ironFound;
            }
            set
            {
                this.ironFound = value;
            }
        }

        public uint ItemsCooked
        {
            get
            {
                return this.itemsCooked;
            }
            set
            {
                this.itemsCooked = value;
            }
        }

        public uint ItemsCrafted
        {
            get
            {
                return this.itemsCrafted;
            }
            set
            {
                this.itemsCrafted = value;
            }
        }

        public uint ItemsShipped
        {
            get
            {
                return this.itemsShipped;
            }
            set
            {
                this.itemsShipped = value;
            }
        }

        public uint MonstersKilled
        {
            get
            {
                return this.monstersKilled;
            }
            set
            {
                this.monstersKilled = value;
            }
        }

        public uint MysticStonesCrushed
        {
            get
            {
                return this.mysticStonesCrushed;
            }
            set
            {
                this.mysticStonesCrushed = value;
            }
        }

        public uint NotesFound
        {
            get
            {
                return this.notesFound;
            }
            set
            {
                this.notesFound = value;
            }
        }

        public uint OtherPreciousGemsFound
        {
            get
            {
                return this.otherPreciousGemsFound;
            }
            set
            {
                this.otherPreciousGemsFound = value;
            }
        }

        public uint PiecesOfTrashRecycled
        {
            get
            {
                return this.piecesOfTrashRecycled;
            }
            set
            {
                this.piecesOfTrashRecycled = value;
            }
        }

        public uint PreservesMade
        {
            get
            {
                return this.preservesMade;
            }
            set
            {
                this.preservesMade = value;
            }
        }

        public uint PrismaticShardsFound
        {
            get
            {
                return this.prismaticShardsFound;
            }
            set
            {
                this.prismaticShardsFound = value;
            }
        }

        public uint QuestsCompleted
        {
            get
            {
                return this.questsCompleted;
            }
            set
            {
                this.questsCompleted = value;
            }
        }

        public uint RabbitWoolProduced
        {
            get
            {
                return this.rabbitWoolProduced;
            }
            set
            {
                this.rabbitWoolProduced = value;
            }
        }

        public uint RocksCrushed
        {
            get
            {
                return this.rocksCrushed;
            }
            set
            {
                this.rocksCrushed = value;
            }
        }

        public uint SeedsSown
        {
            get
            {
                return this.seedsSown;
            }
            set
            {
                this.seedsSown = value;
            }
        }

        public uint SheepWoolProduced
        {
            get
            {
                return this.sheepWoolProduced;
            }
            set
            {
                this.sheepWoolProduced = value;
            }
        }

        public uint SlimesKilled
        {
            get
            {
                return this.slimesKilled;
            }
            set
            {
                this.slimesKilled = value;
            }
        }

        public uint StarLevelCropsShipped
        {
            get
            {
                return this.starLevelCropsShipped;
            }
            set
            {
                this.starLevelCropsShipped = value;
            }
        }

        public uint StepsTaken
        {
            get
            {
                return this.stepsTaken;
            }
            set
            {
                this.stepsTaken = value;
            }
        }

        public uint SticksChopped
        {
            get
            {
                return this.sticksChopped;
            }
            set
            {
                this.sticksChopped = value;
            }
        }

        public uint StoneGathered
        {
            get
            {
                return this.stoneGathered;
            }
            set
            {
                this.stoneGathered = value;
            }
        }

        public uint StumpsChopped
        {
            get
            {
                return this.stumpsChopped;
            }
            set
            {
                this.stumpsChopped = value;
            }
        }

        public uint TimesFished
        {
            get
            {
                return this.timesFished;
            }
            set
            {
                this.timesFished = value;
            }
        }

        public uint TimesUnconscious
        {
            get
            {
                return this.timesUnconscious;
            }
            set
            {
                this.timesUnconscious = value;
            }
        }

        public uint TrufflesFound
        {
            get
            {
                return this.trufflesFound;
            }
            set
            {
                this.trufflesFound = value;
            }
        }

        public uint WeedsEliminated
        {
            get
            {
                return this.weedsEliminated;
            }
            set
            {
                this.weedsEliminated = value;
            }
        }
    }
}
