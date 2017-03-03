using Microsoft.Xna.Framework;

namespace StardewValleySave {
    public class NPC : Character {
        public string defaultMap;
        public string loveInterest;
        public string birthday_Season;
        public int age;
        public int manners;
        public int socialAnxiety;
        public int optimism;
        public int gender;
        public int id = -1;
        public int homeRegion;
        public int daysUntilBirthing = -1;
        public int daysAfterLastBirth = -1;
        public int birthday_Day;
        public int moveTowardPlayerThreshold;
        public bool isInvisible;
        public bool followSchedule = true;
        public bool datable;
        public bool datingFarmer;
        public bool divorcedFromFarmer;
        public int daysMarried;

        protected int defaultFacingDirection;
        private Vector2 defaultPosition;
        private bool isWalkingInSquare;
        private bool isWalkingTowardPlayer;

        public int DefaultFacingDirection {
            get {
                return defaultFacingDirection;
            }
            set {
                defaultFacingDirection = value;
            }
        }

        public string DefaultMap {
            get {
                return defaultMap;
            }
            set {
                defaultMap = value;
            } 
        }

        public Vector2 DefaultPosition {
            get {
                return defaultPosition;
            }
            set {
                defaultPosition = value;
            }
        }

        public bool IsWalkingInSquare {
            get {
                return isWalkingInSquare;
            }
            set {
                isWalkingInSquare = value;
            }
        }

        public bool IsWalkingTowardPlayer {
            get {
                return isWalkingTowardPlayer;
            }
            set {
                isWalkingTowardPlayer = value;
            }
        }

        public virtual bool IsMonster
        {
            get
            {
                return false;
            }
        }

    }
}
