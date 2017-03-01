using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FarmEditor.Model;
using GalaSoft.MvvmLight;
using TiledSharp;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;

namespace FarmEditor.ViewModel {
    public class CanvasGrid : ViewModelBase {
        private int _height;
        private int _width;
        private TmxMap map;

        public ObservableCollection<Tile> LayerBack { get; set; }

        public Dictionary<int, BitmapImage> TileImages;

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
            TileImages = new Dictionary<int, BitmapImage>();

            map = new TmxMap("Maps\\Farm.tmx");

            LayerBack = new ObservableCollection<Tile>();

            _width = map.Width;
            _height = map.Height;

            var back = map.Layers["Back"];
            var paths = map.Layers["Paths"];

            GetSprites();

            foreach (var tile in back.Tiles) {

                if (tile.Gid == 0 || tile.Gid == 16) {
                    continue;
                }

                var a = new Tile();
                a.Height = 16;
                a.Width = 16;
                a.X = tile.X*16;
                a.Y = tile.Y*16;


                a.Image = TileImages[tile.Gid];
                LayerBack.Add(a);
            }

            
        }

        private void GetSprites() {
            foreach (var tileset in map.Tilesets) {
                if (!File.Exists(tileset.Image.Source)) {
                    Console.WriteLine("tileset not found");
                    continue;
                }

                var spriteSheet = ToBitmapImage(new Bitmap(tileset.Image.Source));
                var xSprites = spriteSheet.PixelWidth / tileset.TileWidth;
                var ySprites = spriteSheet.PixelHeight / tileset.TileHeight;

                int tId = tileset.FirstGid;

                for (var y = 0; y < ySprites; y++) {
                    for (var x = 0; x < xSprites; x++) {
                        var bitmapSource = new CroppedBitmap(spriteSheet, new Int32Rect(x * tileset.TileWidth, y * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight)) as BitmapSource;
                        TileImages.Add(tId++, BitmapSourceToImage(bitmapSource));
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

        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
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

        public static BitmapImage BitmapSourceToImage(BitmapSource bitmapSource)
        {

            //convert image format
            var src = new FormatConvertedBitmap();
            src.BeginInit();
            src.Source = bitmapSource;
            src.DestinationFormat = PixelFormats.Bgra32;
            src.EndInit();

            //copy to bitmap
            var bitmap = new Bitmap(src.PixelWidth, src.PixelHeight, PixelFormat.Format32bppArgb);
            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            src.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bitmap.UnlockBits(data);

            return ToBitmapImage(bitmap);
        }
    }
}