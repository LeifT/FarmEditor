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
using StardewValleySave;
using StardewValleySave.Locations;
using TiledSharp;

namespace FarmEditor.ViewModel {
    public class CanvasGrid : ViewModelBase {
        private readonly TmxMap _map;
        private int _canvasHeight;
        private int _canvasWidth;
        private Dictionary<int, BitmapImage> _tileImages;
        private Dictionary<int, BitmapImage> _objectSpriteSheet;
        private Dictionary<int, BitmapImage> _bigCraftablespritesheet;

        public CanvasGrid() {
            var saves = SaveGame.GetSaves();

            var save = SaveGame.LoadSave(saves[1].Filename);
            _map = new TmxMap(string.Concat("Maps\\", Enum.GetName(typeof(Farm.FarmType), save.whichFarm), ".tmx"));

            _canvasWidth = _map.Width;
            _canvasHeight = _map.Height;

            PopulateMapSpriteDictionary();
            AddTilesToCanvas();

            _objectSpriteSheet = SpritesheetToDictionary("Maps\\springobjects.png", 16, 16);
            _bigCraftablespritesheet = SpritesheetToDictionary("TileSheets\\Craftables.png", 16, 32);

            var farm = save.locations.FirstOrDefault(location => location.name.Equals("Farm"));

            // TODO: Load FarmHouse

            // TODO: Load Geenhouse

            // TODO: Load Dirt

            // Load Objects
            foreach (var farmObject in farm.objects) {
                if (farmObject.Value.GetType().IsAssignableFrom(typeof(StardewValleySave.Objects.Object))) {
                    if (farmObject.Value.bigCraftable) {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X * 16, farmObject.Value.tileLocation.Y * 16 - 16, 2, 16, 32, _bigCraftablespritesheet[farmObject.Value.parentSheetIndex]));
                    } else {
                        Tiles.Add(new Tile(farmObject.Value.tileLocation.X * 16, farmObject.Value.tileLocation.Y * 16, 2, 16, 16, _objectSpriteSheet[farmObject.Value.parentSheetIndex]));
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
        
        private void AddTilesToCanvas() {
            Tiles = new ObservableCollection<Tile>();
            var zIndex = 0;

            foreach (var mapLayer in _map.Layers) {
                if (!mapLayer.Name.Equals("Paths")) {
                    foreach (var tile in mapLayer.Tiles) {
                        if (tile.Gid != 0) {
                            Tiles.Add(new Tile(tile.X * 16, tile.Y * 16, zIndex, 16, 16, _tileImages[tile.Gid]));
                        }
                    }
                }
                zIndex++;
            }
        }

        private Dictionary<int, BitmapImage> SpritesheetToDictionary(string name, int width, int height, int startOffset = 0) {
            Dictionary<int, BitmapImage> tiles = new Dictionary<int, BitmapImage>();
            var spriteSheet = BitmapConverter.ToBitmapImage(new Bitmap(name));
            var tileId = startOffset;

            var xSprites = spriteSheet.PixelWidth / width;
            var ySprites = spriteSheet.PixelHeight / height;

            for (var y = 0; y < ySprites; y++) {
                for (var x = 0; x < xSprites; x++) {
                    var bitmapSource = new CroppedBitmap(spriteSheet, new Int32Rect(x * width, y * height, width, height)) as BitmapSource;
                    tiles.Add(tileId++, BitmapConverter.BitmapSourceToImage(bitmapSource)); 
                }
            }

            return tiles;
        }

        private void PopulateMapSpriteDictionary() {
            _tileImages = new Dictionary<int, BitmapImage>();

            foreach (var tileset in _map.Tilesets) {
                var spriteDictionary = SpritesheetToDictionary(tileset.Image.Source, tileset.TileWidth, tileset.TileHeight, tileset.FirstGid);
                spriteDictionary.ToList().ForEach(x => _tileImages[x.Key] = x.Value);
            }
        }
    }
}