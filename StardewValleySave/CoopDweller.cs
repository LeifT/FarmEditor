namespace StardewValleySave {
    public class CoopDweller : Character {
        public int daysToLay;
        public int daysSinceLastLay;
        public int defaultProduceIndex;
        public int friendshipTowardFarmer;
        public int daysSinceLastFed;
        public int pushAccumulator;
        public int uniqueFrameAccumulator = -1;
        public int age;
        public int ageWhenMature;
        public bool wasFed;
        public bool wasPet;
        public string sound;
        public string type;

        public CoopDweller()
        {
        }

        //public CoopDweller(string type, string name) : base(null, new Vector2((float)(Game1.tileSize * Game1.random.Next(2, 9)), (float)(Game1.tileSize * Game1.random.Next(5, 9))), 2, name)
        //{
        //    this.type = type;
        //    if (type == "WhiteChicken")
        //    {
        //        this.daysToLay = 1;
        //        this.ageWhenMature = 1;
        //        this.defaultProduceIndex = 176;
        //        this.sound = "cluck";
        //        //this.sprite = new AnimatedSprite(Game1.content.Load<Texture2D>("Animals\\BabyWhiteChicken"), 0, Game1.tileSize, Game1.tileSize);
        //        return;
        //    }
        //    if (type == "BrownChicken")
        //    {
        //        this.daysToLay = 1;
        //        this.ageWhenMature = 1;
        //        this.defaultProduceIndex = 180;
        //        this.sound = "cluck";
        //        //this.sprite = new AnimatedSprite(Game1.content.Load<Texture2D>("Animals\\BabyBrownChicken"), 0, Game1.tileSize, Game1.tileSize);
        //        return;
        //    }
        //    if (type == "Duck")
        //    {
        //        this.daysToLay = 2;
        //        this.ageWhenMature = 1;
        //        this.defaultProduceIndex = 442;
        //        this.sound = "cluck";
        //        //this.sprite = new AnimatedSprite(Game1.content.Load<Texture2D>("Animals\\BabyBrownChicken"), 0, Game1.tileSize, Game1.tileSize);
        //        return;
        //    }
        //    if (type == "Rabbit")
        //    {
        //        this.daysToLay = 4;
        //        this.ageWhenMature = 3;
        //        this.defaultProduceIndex = 440;
        //        this.sound = "rabbit";
        //        //this.sprite = new AnimatedSprite(Game1.content.Load<Texture2D>("Animals\\BabyRabbit"), 0, Game1.tileSize, Game1.tileSize);
        //        return;
        //    }
        //    if (type != "Dinosaur")
        //    {
        //        return;
        //    }
        //    this.daysToLay = 7;
        //    this.ageWhenMature = 0;
        //    this.defaultProduceIndex = 107;
        //    //this.sprite = new AnimatedSprite(Game1.content.Load<Texture2D>("Animals\\Dinosaur"), 0, Game1.tileSize, Game1.tileSize);
        //}
    }
}
