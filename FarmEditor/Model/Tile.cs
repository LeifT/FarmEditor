using System;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace FarmEditor.Model
{
   public class Tile : ObservableObject {
        public Tile(double x, double y, double width, double height, BitmapSource image, bool flipped = false, int z = -1) {
            Width = width;
            Height = height;
            _x = x;
            _y = y - (height - 16);
            _z = z == -1 ? Y + Height : z;
            Image = image;
            Flipped = flipped ? -1 : 1;
        }

       private double _x;
       private double _y;
       private double _z;

       public double X {
           get { return _x; }
           set {
               if (Math.Abs(_x - value) > double.Epsilon) {
                   _x = value;
                    RaisePropertyChanged();
               }
           }
       }

        public double Y
        {
            get { return _y; }
            set
            {
                if (Math.Abs(_y - value) > double.Epsilon) {
                    _y = value;
                    Z = _y + Height;
                    RaisePropertyChanged();
                }
            }
        }

        public double Z
        {
            get { return _z; }
            set
            {
                if (Math.Abs(_z - value) > double.Epsilon)
                {
                    _z = value;
                    RaisePropertyChanged();
                }
            }
        }
        public double Width { get; set; }
        public double Height { get; set; }
        public BitmapSource Image { get; set; }
        public int Flipped { get; set; }
    }
}
