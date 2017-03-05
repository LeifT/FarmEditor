using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model
{
   public class Tile : ObservableObject {
        public Tile(double x, double y, double z, double width, double height, BitmapSource image, double flip = 1) {
            X = x;
            Y = y;
            Z = z;
            Width = width;
            Height = height;
            Image = image;
            Flip = flip;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public BitmapSource Image { get; set; }
        public double Flip { get; set; }
    }
}
