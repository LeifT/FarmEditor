using Microsoft.Xna.Framework.Input;

namespace StardewValleySave {
    public struct InputButton {
        public Keys key;

        public bool mouseLeft;

        public bool mouseRight;

        public InputButton(Keys key)
        {
            this.key = key;
            this.mouseLeft = false;
            this.mouseRight = false;
        }

        public InputButton(bool mouseLeft)
        {
            this.key = Keys.None;
            this.mouseLeft = mouseLeft;
            this.mouseRight = !mouseLeft;
        }

        public override string ToString()
        {
            if (this.mouseLeft)
            {
                return "Left-Click";
            }
            if (this.mouseRight)
            {
                return "Right-Click";
            }
            switch (this.key)
            {
                case Keys.D0:
                    {
                        return "0";
                    }
                case Keys.D1:
                    {
                        return "1";
                    }
                case Keys.D2:
                    {
                        return "2";
                    }
                case Keys.D3:
                    {
                        return "3";
                    }
                case Keys.D4:
                    {
                        return "4";
                    }
                case Keys.D5:
                    {
                        return "5";
                    }
                case Keys.D6:
                    {
                        return "6";
                    }
                case Keys.D7:
                    {
                        return "7";
                    }
                case Keys.D8:
                    {
                        return "8";
                    }
                case Keys.D9:
                    {
                        return "9";
                    }
            }
            return this.key.ToString().Replace("Oem", "");
        }
    }
}
