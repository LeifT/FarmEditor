using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model
{
   public class Tile : ObservableObject {
       public Tile(double x, double y, double z, double width, double height, BitmapImage image) {
           X = x;
           Y = y;
           Z = z;
           Width = width;
           Height = height;
           Image = image;
       }
       public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public BitmapImage Image { get; set; }
    }
}
