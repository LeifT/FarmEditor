using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model
{
   public class Tile : ObservableObject {
        public Tile(double x, double y, double width, double height, BitmapSource image, int z = -1) {
            X = x;
            Y = y - (height - 16);
            Width = width;
            Height = height;
            Image = image;

            if (z == -1) {
                Z = Y + height;
            } else {
                Z = z;
            }
            
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public BitmapSource Image { get; set; }
    }
}
