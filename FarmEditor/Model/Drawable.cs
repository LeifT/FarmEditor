using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model {
    public interface IDrawable  {
        double X { get; set; }
        double Y { get; set; }
        //double Z { get; set; }
        double Width { get; }
        double Height { get; }
        BitmapSource Image { get; set; }
        int Flipped { get; }
    }
}
