using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model
{
   public class Tile : ObservableObject {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public BitmapImage Image { get; set; }
    }
}
