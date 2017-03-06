using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using FarmEditor.Model;
using FarmEditor.Utils;
using GalaSoft.MvvmLight;
using Microsoft.Xna.Framework;
using StardewValleySave;
using StardewValleySave.Buildings;
using StardewValleySave.Locations;
using StardewValleySave.Objects;
using StardewValleySave.TerrainFeatures;
using TiledSharp;
using Color = Microsoft.Xna.Framework.Color;
using Object = StardewValleySave.Objects.Object;

namespace FarmEditor.ViewModel {
    public class CanvasGrid : ViewModelBase {
        private readonly TmxMap _map;
        private int _canvasHeight;
        private int _canvasWidth;

        private readonly Dictionary<int, int> _dirtmap = new Dictionary<int, int> { { 0000, 0 }, { 0001, 15 }, { 0010, 12 }, { 0011, 11 }, { 0100, 4 }, { 0101, 3 }, { 0110, 8 }, { 0111, 7 }, { 1000, 13 }, { 1001, 14 }, { 1010, 9 }, { 1011, 10 }, { 1100, 1 }, { 1101, 2 }, { 1110, 5 }, { 1111, 6 } };

        private readonly Dictionary<int, int> _fenceMap = new Dictionary<int, int> {
                { 0000,  5 },
                { 0001,  9 },
                { 0010,  3 },
                { 0011,  8 },
                { 0100,  5 },
                { 0101,  2 },
                { 0110,  3 },
                { 0111,  2 },
                { 1000, 10 },
                { 1001,  7 },
                { 1010,  6 },
                { 1011,  7 },
                { 1100,  0 },
                { 1101,  4 },
                { 1110,  0 },
                { 1111,  4 },
            };

        private Dictionary<int, BitmapSource> _bigCraftablespritesheet;
        private Dictionary<int, BitmapSource> _cropSpriteSheet;
        private Dictionary<int, BitmapSource> _dirtTexture;
        private Dictionary<int, BitmapSource> _grassTexture;
        private Dictionary<int, BitmapSource> _objectSpriteSheet;
        private Dictionary<int, BitmapSource> _tileImages;

        private readonly BitmapImage[] _trees = new BitmapImage[3];
        private readonly BitmapImage[] _fences = new BitmapImage[5];

        private BitmapSource _fruitTrees;
        private BitmapSource _mouseCursors;
        private BitmapSource _barnTexture;
        private BitmapSource _deluxeBarnTexture;

        readonly Random _rand = new Random();
        private Farm _farm;

        public CanvasGrid() {
            var saves = SaveGame.GetSaves();

            var save = SaveGame.LoadSave(saves[1].Filename);
            _map = new TmxMap(string.Concat("Maps\\", Enum.GetName(typeof(Farm.FarmType), save.whichFarm), ".tmx"));
            _farm = save.locations.FirstOrDefault(location => location.name.Equals("Farm")) as Farm;

            _canvasWidth = _map.Width;
            _canvasHeight = _map.Height;

            PopulateSprites();
            AddTilesToCanvas();

            // TODO: Draw FarmHouse

            // TODO: Draw Greenhouse

            // TODO: Draw Buildings
            DrawBuildings(_farm);

            DrawTerrainFeatures(_farm);

            // Load Objects
            DrawObjects(_farm);
        }

        public ObservableCollection<Tile> Tiles { get; set; }

        public int CanvasWidth {
            get { return _canvasWidth; }
            set {
                if (_canvasWidth == value) {
                    return;
                }

                _canvasWidth = value;
                RaisePropertyChanged();
            }
        }

        public int CanvasHeight {
            get { return _canvasHeight; }
            set {
                if (_canvasHeight == value) {
                    return;
                }

                _canvasHeight = value;
                RaisePropertyChanged();
            }
        }

        private void PopulateSprites() {
            PopulateMapSprites();
            _objectSpriteSheet = SpritesheetToDictionary("Maps\\springobjects.png", 16, 16);
            _bigCraftablespritesheet = SpritesheetToDictionary("TileSheets\\Craftables.png", 16, 32);
            _cropSpriteSheet = SpritesheetToDictionary("TileSheets\\crops.png", 16, 32);
            _dirtTexture = SpritesheetToDictionary("TerrainFeatures\\hoeDirt.png", 16, 16);
            _grassTexture = SpritesheetToDictionary("TerrainFeatures\\grass.png", 15, 20);

            _trees[0] = BitmapConverter.BitmapToBitmapImage(new Bitmap("TerrainFeatures\\tree1_spring.png"));
            _trees[1] = BitmapConverter.BitmapToBitmapImage(new Bitmap("TerrainFeatures\\tree2_spring.png"));
            _trees[2] = BitmapConverter.BitmapToBitmapImage(new Bitmap("TerrainFeatures\\tree3_spring.png"));

            _fences[0] = BitmapConverter.BitmapToBitmapImage(new Bitmap("LooseSprites\\Fence1.png"));
            _fences[1] = BitmapConverter.BitmapToBitmapImage(new Bitmap("LooseSprites\\Fence2.png"));
            _fences[2] = BitmapConverter.BitmapToBitmapImage(new Bitmap("LooseSprites\\Fence3.png"));
            _fences[3] = BitmapConverter.BitmapToBitmapImage(new Bitmap("LooseSprites\\Fence5.png"));

            _fruitTrees = BitmapConverter.BitmapToBitmapImage(new Bitmap("TileSheets\\fruitTrees.png"));
            _mouseCursors = BitmapConverter.BitmapToBitmapImage(new Bitmap("LooseSprites\\Cursors.png"));

            _barnTexture = BitmapConverter.BitmapToBitmapImage(new Bitmap("Buildings\\Barn.png"));
            _deluxeBarnTexture = BitmapConverter.BitmapToBitmapImage(new Bitmap("Buildings\\Deluxe Barn.png"));


        }

        private void AddTilesToCanvas() {
            Tiles = new ObservableCollection<Tile>();
            var zIndex = 0;

            foreach (var mapLayer in _map.Layers) {
                switch (mapLayer.Name) {
                    case "Back":
                        zIndex = int.MinValue;
                        break;
                    case "Buildings":
                        zIndex = int.MinValue + 1;
                        break;
                    case "Front":
                        zIndex = -1;
                        break;
                    case "AlwaysFront":
                        zIndex = int.MaxValue;
                        break;
                }

                if (mapLayer.Name.Equals("Front")) {
                    foreach (var tile in mapLayer.Tiles) {
                        if (tile.Gid != 0) {
                            Tiles.Add(new Tile(tile.X * 16, tile.Y * 16, 16, 16, _tileImages[tile.Gid], false, tile.Y * 16 + 17));
                        }
                    }
                } else if (!mapLayer.Name.Equals("Paths")) {
                    foreach (var tile in mapLayer.Tiles) {
                        if (tile.Gid != 0) {
                            Tiles.Add(new Tile(tile.X * 16, tile.Y * 16, 16, 16, _tileImages[tile.Gid], false, zIndex));
                        }
                    }
                }
            }
        }

        private Dictionary<int, BitmapSource> SpritesheetToDictionary(string name, int width, int height, int startOffset = 0) {
            var tiles = new Dictionary<int, BitmapSource>();
            var spriteSheet = BitmapConverter.BitmapToBitmapImage(new Bitmap(name));
            var tileId = startOffset;

            var xSprites = spriteSheet.PixelWidth/width;
            var ySprites = spriteSheet.PixelHeight/height;

            for (var y = 0; y < ySprites; y++) {
                for (var x = 0; x < xSprites; x++) {
                    var bitmapSource = new CroppedBitmap(spriteSheet, new Int32Rect(x*width, y*height, width, height)) as BitmapSource;
                    tiles.Add(tileId++, bitmapSource);
                }
            }

            return tiles;
        }

        private void PopulateMapSprites() {
            _tileImages = new Dictionary<int, BitmapSource>();

            foreach (var tileset in _map.Tilesets) {
                var spriteDictionary = SpritesheetToDictionary(tileset.Image.Source, tileset.TileWidth,
                    tileset.TileHeight, tileset.FirstGid);
                spriteDictionary.ToList().ForEach(x => _tileImages[x.Key] = x.Value);
            }
        }

        private void DrawBuildings(BuildableGameLocation gameLocation) {

            foreach (var building in gameLocation.buildings) {

                var barn = building as Barn;

                if (barn != null) {
                    DrawBarn(barn);
                }
            }
        }

        private void DrawBarn(Barn barn) {
            if (barn.daysOfConstructionLeft > 0) {
                // TODO: Draw under constrcution
                return;
            }

            // TODO: Draw Shadow
            
            var location = new Vector2(barn.tileX + barn.animalDoor.X, barn.tileY + barn.animalDoor.Y - 1) * 16;
            BitmapSource image = new CroppedBitmap(_deluxeBarnTexture, new Int32Rect(32, 112, 32, 16));
            Tiles.Add(new Tile(location.X, location.Y, image.Width, image.Height, image));

            location = new Vector2(barn.tileX + barn.animalDoor.X, barn.tileY + barn.animalDoor.Y) * 16;
            image = new CroppedBitmap(_deluxeBarnTexture, new Int32Rect(64, 112, 32, 16));
            Tiles.Add(new Tile(location.X, location.Y, image.Width, image.Height, image));

            location = new Vector2((barn.tileX + barn.animalDoor.X) * 16, (barn.tileY + barn.animalDoor.Y) * 16 - 31);
            image = new CroppedBitmap(_deluxeBarnTexture, new Int32Rect(0, 112, 32, 16));
            Tiles.Add(new Tile(location.X, location.Y, image.Width, image.Height, image, false, barn.tileY * 16 + barn.tilesHigh * 16));
            
            location = new Vector2((barn.tileX + barn.animalDoor.X) * 16, (barn.tileY + barn.animalDoor.Y) * 16 - 19);
            image = new CroppedBitmap(_deluxeBarnTexture, new Int32Rect(0, 112, 32, 16));
            Tiles.Add(new Tile(location.X, location.Y, image.Width, image.Height, image, false, barn.tileY * 16 + barn.tilesHigh * 16));

            location = new Vector2(barn.tileX * 16, barn.tileY * 16 + barn.tilesHigh * 16);
            image = new CroppedBitmap(_deluxeBarnTexture, new Int32Rect(0, 0, 112, 112));
            Tiles.Add(new Tile(location.X, location.Y - 16, image.Width, image.Height, image));
        }

        private void DrawObjects(GameLocation gameLocation) {
            foreach (var farmObject in gameLocation.objects) {
                if (farmObject.Value.GetType().IsAssignableFrom(typeof(Object))) {
                    if (farmObject.Value.bigCraftable) {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X * 16, farmObject.Value.tileLocation.Y * 16, 16, 32, _bigCraftablespritesheet[farmObject.Value.parentSheetIndex]));
                    }
                    else {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X * 16, farmObject.Value.tileLocation.Y * 16, 16, 16, _objectSpriteSheet[farmObject.Value.parentSheetIndex], farmObject.Value.flipped));
                    }
                    continue;
                }

                Fence fence = farmObject.Value as Fence;

                if (fence != null) {
                    DrawFence(fence, farmObject.Key);
                }
            }
        }
        
        private void DrawFence(Fence fence, Vector2 location) {
            int fenceIndex = 1;

            if (fence.health > 1) {
                int fenceType = 0;
                var multiplier = 1;

                for (var i = -1; i < 2; i++) {
                    for (var j = -1; j < 2; j++) {
                        // Skip corners and middle
                        if (Math.Abs(i) == Math.Abs(j)) {
                            continue;
                        }

                        var neighbourKey = new Vector2(location.X + i, location.Y + j);
                        Object gameObject;

                        if (_farm.objects.TryGetValue(neighbourKey, out gameObject)) {
                            var neighbour = gameObject as Fence;

                            if (neighbour != null) {
                                if (!neighbour.isGate && !(neighbour.health <= 1f) && (fence.whichType == 4 || fence.whichType == neighbour.whichType)) {
                                    fenceType += multiplier;
                                    
                                }
                            }
                        }
                        multiplier = multiplier * 10;
                    }
                }
                fenceIndex = _fenceMap[fenceType];

                if (fence.isGate) {
                    if (fenceType == 110) {
                        Tiles.Add(new Tile(location.X * 16 + 1, location.Y * 16 -  4, 24, 32, new CroppedBitmap(_fences[0], new Int32Rect(fence.gatePosition == 88 ? 16 : 0, 160, 16, 16))));
                        Tiles.Add(new Tile(location.X * 16 + 1, location.Y * 16 + 10, 24, 32, new CroppedBitmap(_fences[0], new Int32Rect(fence.gatePosition == 88 ? 16 : 0, 176, 16, 16))));
                        return;
                    }

                    if (fenceType == 1001) {
                        var image = new CroppedBitmap(_fences[0], new Int32Rect(fence.gatePosition == 88 ? 24 : 0, 128, 24, 32));
                        Tiles.Add(new Tile(location.X * 16 - 4, location.Y * 16, 24, 32, image));
                        return;
                    }
                    fenceIndex = 17;
                }

                // TODO Draw object on top
            }
            Tiles.Add(new Tile(location.X * 16, location.Y * 16, 16, 32, new CroppedBitmap(_fences[fence.whichType - 1], new Int32Rect(fenceIndex * 16 % (int)_fences[0].Width, fenceIndex * 16 / (int)_fences[0].Width * 32, 16, 32))));
        }

        private void DrawTerrainFeatures(GameLocation gameLocation) {
            foreach (var terrainFeature in gameLocation.terrainFeatures) {
                var hoeDirt = terrainFeature.Value as HoeDirt;

                if (hoeDirt != null) {
                    DrawDirt(hoeDirt, terrainFeature.Key);
                    continue;
                }

                var grass = terrainFeature.Value as Grass;

                if (grass != null) {
                    DrawGrass(grass, terrainFeature.Key);
                    continue;
                }

                var tree = terrainFeature.Value as Tree;

                if (tree != null) {
                    DrawTree(tree, terrainFeature.Key);
                    continue;
                }
                
                var fruitTree = terrainFeature.Value as FruitTree;

                if (fruitTree != null) {
                    DrawFruitTree(fruitTree, terrainFeature.Key);
                }

                //TODO: Draw Flooring

                //TODO: Draw GiantCrop
            }
        }

        private void DrawGrass(Grass grass, Vector2 location) {
            for (int i = 0; i < grass.numberOfWeeds; i++) {
                float x;
                float y;

                if (i != 4) {
                    x = i % 2 * 8 + _rand.Next(-2, 3);  
                    y = i * 4 + _rand.Next(-2, 3); 
                } else {
                    x = 4 + _rand.Next(-2, 3);
                    y = 4 + _rand.Next(-2, 3);
                }

                Tiles.Add(new Tile(location.X * 16 + x, location.Y * 16 + y, 15, 20, _grassTexture[_rand.Next(3)], _rand.Next(0,2) == 1));
            }
        }

        private void DrawDirt(HoeDirt hoeDirt, Vector2 location) {
            var hoed = 0;
            var watered = 0;
            var multiplier = 1;
            
            for (var i = -1; i < 2; i++) {
                for (var j = -1; j < 2; j++) {
                    // Skip corners and middle
                    if (Math.Abs(i) == Math.Abs(j)) {
                        continue;
                    }

                    var neighbourKey = new Vector2(location.X + i, location.Y + j);
                    TerrainFeature feature;

                    if (_farm.terrainFeatures.TryGetValue(neighbourKey, out feature)) {
                        var neighbour = feature as HoeDirt;

                        if (neighbour != null) {
                            hoed += multiplier;

                            if (neighbour.state == 1) {
                                watered += multiplier;
                            }
                        }
                    }
                    multiplier = multiplier * 10;
                }
            }

            // Draw hoed dirt
            var spritesheetIndex = _dirtmap[hoed] / 4 * 4 + _dirtmap[hoed];
            Tiles.Add(new Tile(location.X * 16, location.Y * 16, 16, 16, _dirtTexture[spritesheetIndex]));

            // Draw watered hoed dirt
            if (hoeDirt.state == 1) {
                spritesheetIndex = _dirtmap[watered] / 4 * 4 + _dirtmap[watered] + 4;
                Tiles.Add(new Tile(location.X * 16, location.Y * 16, 16, 16, _dirtTexture[spritesheetIndex]));
            }

            // TODO: Draw fertilizer

            // TODO: Draw crop
            DrawCrop(hoeDirt.crop, location);
        }

        private void DrawCrop(Crop crop, Vector2 location) {
            if (crop != null) {
                int growthStage;
                var number = (int) location.X * 7 + (int) location.Y * 11;

                if (crop.dead) {
                    Tiles.Add(new Tile(location.X * 16, location.Y* 16, 16, 32, _cropSpriteSheet[203 + number % 4], crop.flip));
                    return;
                }

                if (crop.fullyGrown) {
                    growthStage = crop.dayOfCurrentPhase <= 0 ? 6 : 7;
                } else {
                    growthStage = crop.phaseToShow != -1 ? crop.phaseToShow : crop.currentPhase;

                    if (growthStage > 0 || (number % 2 != 0)) {
                        growthStage++;
                    }
                }

                Tiles.Add(new Tile(location.X*16, location.Y*16, 16, 32, _cropSpriteSheet[crop.rowInSpriteSheet*8 + growthStage], crop.flip));

                if (!crop.tintColor.Equals(Color.White) && crop.currentPhase == crop.phaseDays.Count - 1 && !crop.dead) {
                    if (crop.fullyGrown) {
                        growthStage = crop.dayOfCurrentPhase <= 0 ? 6 : 7;
                    } else {
                        growthStage = crop.currentPhase += 2;
                    }

                    // TODO: Improve this
                    var image = _cropSpriteSheet[crop.rowInSpriteSheet * 8 + growthStage].ColorTint(crop.tintColor.R, crop.tintColor.G, crop.tintColor.B, crop.tintColor.A);
                    Tiles.Add(new Tile(location.X* 16, location.Y*16, 16, 32, image, crop.flip));
                }
            }
        }

        private void DrawTree(Tree tree, Vector2 location) {
            if (tree.growthStage >= 5) {
                // Stump
                BitmapSource image = new CroppedBitmap(_trees[tree.treeType - 1], new Int32Rect(32, 96, 16, 32));
                Tiles.Add(new Tile(location.X * 16, location.Y * 16, 16, 32, image, tree.flipped));

                if (!tree.stump) {
                    // Shadow
                    image = new CroppedBitmap(_mouseCursors, new Int32Rect(663, 1011, 41, 30));
                    Tiles.Add(new Tile(location.X * 16 - 12.8f, location.Y * 16 + 10, 41, 30, image, tree.flipped));

                    // Tree
                    image = new CroppedBitmap(_trees[tree.treeType - 1], new Int32Rect(0, 0, 48, 96));
                    Tiles.Add(new Tile(location.X * 16 - 16, location.Y * 16, 48, 96, image, tree.flipped));
                }
            } else {
                Int32Rect sourceRect;
                switch (tree.growthStage) {
                    case 0: 
                        sourceRect = new Int32Rect(32, 128, 16, 16);
                        break;
                    case 1: 
                        sourceRect = new Int32Rect(0, 128, 16, 16);
                        break;
                    case 2: 
                        sourceRect = new Int32Rect(16, 128, 16, 16);
                        break;
                    default: 
                        sourceRect = new Int32Rect(0, 96, 16, 32);
                        break;
                }

                BitmapSource image = new CroppedBitmap(_trees[tree.treeType - 1], sourceRect);
                Tiles.Add(new Tile(location.X * 16, location.Y * 16, sourceRect.Width, sourceRect.Height, image, tree.flipped));
            }

            // TODO: Draw leaves
        }

        private void DrawFruitTree(FruitTree fruitTree, Vector2 location) {
            // TODO: Check that this works
            if (fruitTree.greenHouseTileTree) {
                var image = new CroppedBitmap(_mouseCursors, new Int32Rect(669, 1957, 16, 16));
                Tiles.Add(new Tile(location.X * 16, location.Y * 16, 16, 16, image));
            }

            if (fruitTree.growthStage > 3) {
                if (fruitTree.stump) {
                    var image = new CroppedBitmap(_fruitTrees, new Int32Rect(384, fruitTree.treeType * 80 + 48, 48, 32));
                    Tiles.Add(new Tile(location.X * 16 - 16, location.Y * 16, 48, 32, image.Source, fruitTree.flipped));
                } else {
                    BitmapSource image;
                    if (fruitTree.struckByLightningCountdown > 0) {
                        image = new CroppedBitmap(_fruitTrees, new Int32Rect(fruitTree.greenHouseTree ? 240 : 192, fruitTree.treeType * 80, 48, 80)).ColorTint(Color.Gray.R, Color.Gray.G, Color.Gray.B, Color.Gray.A);
                    } else {
                        image = new CroppedBitmap(_fruitTrees, new Int32Rect(fruitTree.greenHouseTree ? 240 : 192, fruitTree.treeType * 80, 48, 80));
                    }
                    
                    Tiles.Add(new Tile(location.X * 16 - 16, location.Y * 16, 48, 80, image, fruitTree.flipped));
                }
               
                if (fruitTree.fruitsOnTree > 0) {
                    Tiles.Add(new Tile(location.X * 16 - 16 + location.X * 200f % 16 / 2f, location.Y * 16 - 48 - location.X % 16 / 3f, 16, 16, _objectSpriteSheet[fruitTree.struckByLightningCountdown > 0 ? 382 : fruitTree.indexOfFruit], false, (int)location.Y * 16 + 16));
                }

                if (fruitTree.fruitsOnTree > 1) {
                    Tiles.Add(new Tile(location.X * 16 + 8, location.Y * 16 - 64 + location.X * 232f % 16 / 3f, 16, 16, _objectSpriteSheet[fruitTree.struckByLightningCountdown > 0 ? 382 : fruitTree.indexOfFruit], false, (int)location.Y * 16 + 16));
                }

                if (fruitTree.fruitsOnTree > 2) {
                    Tiles.Add(new Tile(location.X * 16 + location.X * 200f % 16 / 3f, location.Y * 16 - 40 + location.X * 200f % 16 / 3f, 16, 16, _objectSpriteSheet[fruitTree.struckByLightningCountdown > 0 ? 382 : fruitTree.indexOfFruit], false, (int)location.Y * 16 + 16));
                }
            } else {
                var offset = (float) Math.Max(-8, Math.Min(16, Math.Sin(location.X*200f/6.28318530717959)*-16));
                var image = new CroppedBitmap(_fruitTrees, new Int32Rect(fruitTree.growthStage * 48, fruitTree.treeType * 80, 48, 80)) as BitmapSource;
                Tiles.Add(new Tile(location.X * 16 + offset - 28, location.Y * 16 + offset - 16, 48, 80, image, fruitTree.flipped));
            }

            // TODO: Draw leaves
        }
    }
}