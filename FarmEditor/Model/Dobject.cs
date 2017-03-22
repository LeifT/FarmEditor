using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Object = StardewValleySave.Objects.Object;

namespace FarmEditor.Model
{
    public class Dobject : Object, IDrawable {

        private double _x;
        private double _y;

        public double X {
            get {
                return _x;
            }
            set {
                _x = value;
                tileLocation.X = (float) _x / 16;
            }
        }

        public Dobject(double x, double y, BitmapSource image) {
            X = x * 16;
            Y = y * 16;
            Image = image;

            Z = X + Height;
        }

        public double Y {
            get {
                return _y;
            }
            set {
                _y = value;
                tileLocation.Y = (float)_y / 16;
            }
        }

        public double Z { get; set; }

        public double Width => 16;
        public double Height => 16;

        public BitmapSource Image { get; set; }

        public int Flipped => flipped ? -1 : 1;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
