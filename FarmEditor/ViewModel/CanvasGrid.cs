using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using FarmEditor.Model;
using FarmEditor.StardewValley;
using GalaSoft.MvvmLight;
using TiledSharp;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;

namespace FarmEditor.ViewModel {
    public class CanvasGrid : ViewModelBase {
        private int _height;
        private int _width;
        private readonly Dictionary<int, BitmapImage> _tileImages;
        private readonly TmxMap _map;
        private readonly SaveGame _save;

        public ObservableCollection<Tile> Tiles { get; set; }

        public int Width {
            get { return _width; }
            set {
                if (_width == value) {
                    return;
                }

                _width = value;
                RaisePropertyChanged();
            }
        }

        public CanvasGrid() {
            _tileImages = new Dictionary<int, BitmapImage>();
            _map = new TmxMap("Maps\\Farm_Fishing.tmx");

            using (TextReader reader = new StreamReader("Leif_147754338"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SaveGame));
                _save = (SaveGame)serializer.Deserialize(reader);
            }

            Console.WriteLine(_save.Locations.Length);


            Tiles = new ObservableCollection<Tile>();
            _width = _map.Width;
            _height = _map.Height;
            GetSprites();
            var zIndex = 0;

            foreach (var mapLayer in _map.Layers) {
                foreach (var tile in mapLayer.Tiles) {
                    if (tile.Gid == 0) {
                        continue;
                    }

                    var a = new Tile();
                    a.Height = 16;
                    a.Width = 16;
                    a.X = tile.X * 16;
                    a.Y = tile.Y * 16;
                    a.Z = zIndex;

                    a.Image = _tileImages[tile.Gid];
                    Tiles.Add(a);
                }
                zIndex++;
            }
        }

        private void GetSprites() {
            for (int i = 0; i < _map.Tilesets.Count; i++) {
                CutSprites(i);
            }
        }

        private void CutSprites(int i) {
            var spriteSheet = ToBitmapImage(new Bitmap(_map.Tilesets[i].Image.Source));

            int tileId = _map.Tilesets[i].FirstGid;
            var width = _map.Tilesets[i].TileWidth;
            var height = _map.Tilesets[i].TileHeight;

            var xSprites = spriteSheet.PixelWidth/_map.Tilesets[i].TileWidth;
            var ySprites = spriteSheet.PixelHeight/_map.Tilesets[i].TileHeight;

            for (var y = 0; y < ySprites; y++) {
                for (var x = 0; x < xSprites; x++) {
                    var bitmapSource = new CroppedBitmap(spriteSheet, new Int32Rect(x*width, y*height, width, height)) as BitmapSource;
                    _tileImages.Add(tileId++, BitmapSourceToImage(bitmapSource));

                    if (i + 1 < _map.Tilesets.Count) {
                        if (tileId == _map.Tilesets[i + 1].FirstGid) {
                            return;
                        }
                    }
                }
            }
        }

        public int Height {
            get { return _height; }
            set {
                if (_height == value) {
                    return;
                }

                _height = value;
                RaisePropertyChanged();
            }
        }

        public static BitmapImage ToBitmapImage(Bitmap bitmap) {
            using (var stream = new MemoryStream()) {
                bitmap.Save(stream, ImageFormat.Png);

                stream.Position = 0;
                var result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        public static BitmapImage BitmapSourceToImage(BitmapSource bitmapSource) {
            //convert image format
            var src = new FormatConvertedBitmap();
            src.BeginInit();
            src.Source = bitmapSource;
            src.DestinationFormat = PixelFormats.Bgra32;
            src.EndInit();

            //copy to bitmap
            var bitmap = new Bitmap(src.PixelWidth, src.PixelHeight, PixelFormat.Format32bppArgb);
            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            src.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bitmap.UnlockBits(data);

            return ToBitmapImage(bitmap);
        }
    }
}