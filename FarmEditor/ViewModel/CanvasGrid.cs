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
using StardewValleySave.Locations;
using StardewValleySave.TerrainFeatures;
using TiledSharp;
using Color = Microsoft.Xna.Framework.Color;
using Object = StardewValleySave.Objects.Object;

namespace FarmEditor.ViewModel {
    public class CanvasGrid : ViewModelBase {
        private readonly TmxMap _map;
        private Dictionary<int, BitmapImage> _bigCraftablespritesheet;
        private int _canvasHeight;
        private int _canvasWidth;
        private Dictionary<int, BitmapImage> _cropSpriteSheet;
        private Dictionary<int, BitmapImage> _lightTexture;
        private Dictionary<int, BitmapImage> _objectSpriteSheet;
        private Dictionary<int, BitmapImage> _tileImages;

        private GameLocation _farm;

        public CanvasGrid() {
            var saves = SaveGame.GetSaves();

            var save = SaveGame.LoadSave(saves[1].Filename);
            _map = new TmxMap(string.Concat("Maps\\", Enum.GetName(typeof(Farm.FarmType), save.whichFarm), ".tmx"));

            _canvasWidth = _map.Width;
            _canvasHeight = _map.Height;

            LoadSprites();
            AddTilesToCanvas();

            _farm = save.locations.FirstOrDefault(location => location.name.Equals("Farm"));

            // TODO: Load FarmHouse

            // TODO: Load Geenhouse

            // Load dirt
            DrawTerrainFeatures(_farm);

            // Load Objects
            foreach (var farmObject in _farm.objects) {
                if (farmObject.Value.GetType().IsAssignableFrom(typeof(Object))) {
                    if (farmObject.Value.bigCraftable) {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X*16, farmObject.Value.tileLocation.Y*16 - 16,
                            farmObject.Value.tileLocation.Y, 16, 32,
                            _bigCraftablespritesheet[farmObject.Value.parentSheetIndex]));
                    } else {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X*16, farmObject.Value.tileLocation.Y*16,
                            farmObject.Value.tileLocation.Y, 16, 16,
                            _objectSpriteSheet[farmObject.Value.parentSheetIndex]));
                    }
                }
            }
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

        private void LoadSprites() {
            PopulateMapSprites();
            _objectSpriteSheet = SpritesheetToDictionary("Maps\\springobjects.png", 16, 16);
            _bigCraftablespritesheet = SpritesheetToDictionary("TileSheets\\Craftables.png", 16, 32);
            _cropSpriteSheet = SpritesheetToDictionary("TileSheets\\crops.png", 16, 32);
            _lightTexture = SpritesheetToDictionary("TerrainFeatures\\hoeDirt.png", 16, 16);
        }

        private void AddTilesToCanvas() {
            Tiles = new ObservableCollection<Tile>();
            var layer = 0;
            var zIndex = 0;

            foreach (var mapLayer in _map.Layers) {
                switch (layer) {
                    case 0:
                        zIndex = int.MinValue;
                        break;
                    case 1:
                        zIndex = int.MinValue + 1;
                        break;

                    case 2:
                        zIndex = int.MaxValue - 1;
                        break;
                    case 3:
                        zIndex = int.MaxValue;
                        break;
                }

                if (!mapLayer.Name.Equals("Paths")) {
                    foreach (var tile in mapLayer.Tiles) {
                        if (tile.Gid != 0) {
                            Tiles.Add(new Tile(tile.X*16, tile.Y*16, zIndex, 16, 16, _tileImages[tile.Gid]));
                        }
                    }
                }
                layer++;
            }
        }

        private Dictionary<int, BitmapImage> SpritesheetToDictionary(string name, int width, int height,
            int startOffset = 0) {
            var tiles = new Dictionary<int, BitmapImage>();
            var spriteSheet = BitmapConverter.BitmapToBitmapImage(new Bitmap(name));
            var tileId = startOffset;

            var xSprites = spriteSheet.PixelWidth/width;
            var ySprites = spriteSheet.PixelHeight/height;

            for (var y = 0; y < ySprites; y++) {
                for (var x = 0; x < xSprites; x++) {
                    var bitmapSource =
                        new CroppedBitmap(spriteSheet, new Int32Rect(x*width, y*height, width, height)) as BitmapSource;
                    tiles.Add(tileId++, BitmapConverter.BitmapSourceToImage(bitmapSource));
                }
            }

            return tiles;
        }

        private void PopulateMapSprites() {
            _tileImages = new Dictionary<int, BitmapImage>();

            foreach (var tileset in _map.Tilesets) {
                var spriteDictionary = SpritesheetToDictionary(tileset.Image.Source, tileset.TileWidth,
                    tileset.TileHeight, tileset.FirstGid);
                spriteDictionary.ToList().ForEach(x => _tileImages[x.Key] = x.Value);
            }
        }

        readonly Dictionary<int, int> _dirtmap = new Dictionary<int, int> {
                {0000, 0},
                {0001, 15},
                {0010, 12},
                {0011, 11},
                {0100, 4},
                {0101, 3},
                {0110, 8},
                {0111, 7},
                {1000, 13},
                {1001, 14},
                {1010, 9},
                {1011, 10},
                {1100, 1},
                {1101, 2},
                {1110, 5},
                {1111, 6}
            };

        private void DrawTerrainFeatures(GameLocation farm) {
            foreach (var terrainFeature in farm.terrainFeatures) {


                var hoeDirt = terrainFeature.Value as HoeDirt;

                if (hoeDirt != null) {
                    DrawDirt(hoeDirt, terrainFeature.Key);
                    continue;
                }

                var grass = terrainFeature.Value as Grass;

                if (grass != null) {
                    DrawGrass(grass, terrainFeature.Key);
                }

                // TODO: Draw trees
            }
        }

        private void DrawGrass(Grass grass, Vector2 location) {
            
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
                        hoed += multiplier;
                        var neighbour = feature as HoeDirt;

                        if (neighbour?.state == 1) {
                            watered += multiplier;
                        }
                    }

                    multiplier = multiplier * 10;
                }
            }

            // Draw hoed dirt
            var spritesheetIndex = _dirtmap[hoed] / 4 * 4 + _dirtmap[hoed];
            Tiles.Add(new Tile(location.X * 16, location.Y * 16, location.Y, 16, 16, _lightTexture[spritesheetIndex]));

            // Draw watered hoed dirt
            if (hoeDirt.state == 1) {
                spritesheetIndex = _dirtmap[watered] / 4 * 4 + _dirtmap[watered] + 4;
                Tiles.Add(new Tile(location.X * 16, location.Y * 16, location.Y, 16, 16, _lightTexture[spritesheetIndex]));
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
                    // TODO: Check if it works correctly
                    Tiles.Add(new Tile(location.X * 16, location.Y* 16 - 16, location.Y, 16, 32, _cropSpriteSheet[203 + number % 4]));
                } else {
                    if (crop.fullyGrown) {
                        growthStage = crop.dayOfCurrentPhase <= 0 ? 6 : 7;
                    } else {
                        growthStage = crop.phaseToShow != -1 ? crop.phaseToShow : crop.currentPhase;

                        if (growthStage > 0 || (number % 2 != 0)) {
                            growthStage++;
                        }
                    }

                    Tiles.Add(new Tile(location.X*16, location.Y*16 - 16, location.Y, 16, 32, _cropSpriteSheet[crop.rowInSpriteSheet*8 + growthStage]));
                }

                if (!crop.tintColor.Equals(Color.White) && crop.currentPhase == crop.phaseDays.Count - 1 && !crop.dead) {
                    if (crop.fullyGrown) {
                        growthStage = crop.dayOfCurrentPhase <= 0 ? 6 : 7;
                    } else {
                        growthStage = crop.currentPhase += 2;
                    }

                    // TODO: Improve this
                    var image = BitmapConverter.BitmapToBitmapImage(BitmapConverter.BitmapImageToBitmap(_cropSpriteSheet[crop.rowInSpriteSheet*8 + growthStage]).ColorTint(crop.tintColor.R, crop.tintColor.G, crop.tintColor.B, crop.tintColor.A));
                    Tiles.Add(new Tile(location.X*16, location.Y*16 - 16, location.Y, 16, 32, image));
                }
            }
        }
    }
}