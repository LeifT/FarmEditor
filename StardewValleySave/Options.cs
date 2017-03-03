using Microsoft.Xna.Framework.Input;

namespace StardewValleySave {
    public class Options {
        public bool autoRun;
        public bool dialogueTyping;
        public bool fullscreen;
        public bool windowedBorderlessFullscreen;
        public bool showPortraits;
        public bool showMerchantPortraits;
        public bool showMenuBackground;
        public bool playFootstepSounds;
        public bool alwaysShowToolHitLocation;
        public bool hideToolHitLocationWhenInMotion;
        public bool pauseWhenOutOfFocus;
        public bool pinToolbarToggle;
        public bool mouseControls;
        public bool keyboardControls;
        public bool gamepadControls;
        public bool rumble;
        public bool ambientOnlyToggle;
        public bool zoomButtons;
        public bool invertScrollDirection;
        public bool screenFlash;
        public bool hardwareCursor;
        public bool showPlacementTileForGamepad;
        public bool useCrisperNumberFont;
        public float musicVolumeLevel;
        public float soundVolumeLevel;
        public float zoomLevel;
        public float footstepVolumeLevel;
        public float ambientVolumeLevel;
        public float snowTransparency;
        public int preferredResolutionX;
        public int preferredResolutionY;
        public int lightingQuality;

        public InputButton[] actionButton = new InputButton[] { new InputButton(Keys.X), new InputButton(false) };
        public InputButton[] toolSwapButton = new InputButton[0];
        public InputButton[] cancelButton = new InputButton[] { new InputButton(Keys.V) };
        public InputButton[] useToolButton = new InputButton[] { new InputButton(Keys.C), new InputButton(true) };
        public InputButton[] moveUpButton = new InputButton[] { new InputButton(Keys.W) };
        public InputButton[] moveRightButton = new InputButton[] { new InputButton(Keys.D) };
        public InputButton[] moveDownButton = new InputButton[] { new InputButton(Keys.S) };
        public InputButton[] moveLeftButton = new InputButton[] { new InputButton(Keys.A) };
        public InputButton[] menuButton = new InputButton[] { new InputButton(Keys.E), new InputButton(Keys.Escape) };
        public InputButton[] runButton = new InputButton[] { new InputButton(Keys.LeftShift) };
        public InputButton[] tmpKeyToReplace = new InputButton[] { new InputButton(Keys.None) };
        public InputButton[] chatButton = new InputButton[] { new InputButton(Keys.T), new InputButton(Keys.OemQuestion) };
        public InputButton[] mapButton = new InputButton[] { new InputButton(Keys.M) };
        public InputButton[] journalButton = new InputButton[] { new InputButton(Keys.F) };
        public InputButton[] inventorySlot1 = new InputButton[] { new InputButton(Keys.D1) };
        public InputButton[] inventorySlot2 = new InputButton[] { new InputButton(Keys.D2) };
        public InputButton[] inventorySlot3 = new InputButton[] { new InputButton(Keys.D3) };
        public InputButton[] inventorySlot4 = new InputButton[] { new InputButton(Keys.D4) };
        public InputButton[] inventorySlot5 = new InputButton[] { new InputButton(Keys.D5) };
        public InputButton[] inventorySlot6 = new InputButton[] { new InputButton(Keys.D6) };
        public InputButton[] inventorySlot7 = new InputButton[] { new InputButton(Keys.D7) };
        public InputButton[] inventorySlot8 = new InputButton[] { new InputButton(Keys.D8) };
        public InputButton[] inventorySlot9 = new InputButton[] { new InputButton(Keys.D9) };
        public InputButton[] inventorySlot10 = new InputButton[] { new InputButton(Keys.D0) };
        public InputButton[] inventorySlot11 = new InputButton[] { new InputButton(Keys.OemMinus) };
        public InputButton[] inventorySlot12 = new InputButton[] { new InputButton(Keys.OemPlus) };
    }
}
