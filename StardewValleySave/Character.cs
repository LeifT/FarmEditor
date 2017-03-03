using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace StardewValleySave
{
    public class Character {
        [XmlIgnore]
        public Vector2 position;

        [XmlIgnore] 
        public int speed;

        [XmlIgnore]
        public int facingDirection = 2;

        public string name;
        public bool isEmoting;
        public bool isCharging;
        public bool willDestroyObjectsUnderfoot = true;
        public bool isGlowing;
        public bool coloredBorder;
        public bool flip;
        public bool drawOnTop;
        public bool faceTowardFarmer;
        public bool faceAwayFromFarmer;
        public bool ignoreMovementAnimation;
        public float scale = 1f;
        public float timeBeforeAIMovementAgain;
        public float glowingTransparency;
        public float glowRate;

        protected int currentEmote;

        public Vector2 Position {
            get {
                return position;
            }
            set {
                position = value;
            }
        }

        public int Speed {
            get {
                return speed;
            }
            set {
                speed = value;
            }
        }

        public bool IsEmoting {
            get {
                return isEmoting;
            }
            set {
                isEmoting = value;
            }
        }

        public int CurrentEmote {
            get {
                return currentEmote;
            }
            set {
                currentEmote = value;
            }
        }

  
    }
}