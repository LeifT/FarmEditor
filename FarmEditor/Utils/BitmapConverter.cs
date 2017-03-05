using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;

namespace FarmEditor.Utils {
    internal static class BitmapConverter {
        //public static Bitmap BitmapImageToBitmap(BitmapImage bitmapImage) {
        //    using (MemoryStream outStream = new MemoryStream()) {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        //        enc.Save(outStream);
        //        Bitmap bitmap = new Bitmap(outStream);

        //        return new Bitmap(bitmap);
        //    }
        //}

        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap) {
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

        //public static BitmapImage BitmapSourceToImage(BitmapSource bitmapSource) {

        //    // Convert image format
        //    var src = new FormatConvertedBitmap();
        //    src.BeginInit();
        //    src.Source = bitmapSource;
        //    src.DestinationFormat = PixelFormats.Bgra32;
        //    src.EndInit();

        //    // Copy to bitmap
        //    var bitmap = new Bitmap(src.PixelWidth, src.PixelHeight, PixelFormat.Format32bppArgb);
        //    var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        //    src.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height*data.Stride, data.Stride);
        //    bitmap.UnlockBits(data);

        //    return BitmapToBitmapImage(bitmap);
        //}

        // Bitmap to BitmapSource
        public static BitmapSource ConvertBitmap(Bitmap source) {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        // BitmapSource to Bitmap
        public static Bitmap BitmapFromSource(BitmapSource bitmapsource) {
            Bitmap bitmap;
            using (var outStream = new MemoryStream()) {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        public static Bitmap ColorTint(this Bitmap sourceBitmap, float blueTint, float greenTint, float redTint, float alphaTint) {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            for (int k = 0; k < pixelBuffer.Length; k += 4) {
                var red   = pixelBuffer[k]     * redTint   / 255f;
                var green = pixelBuffer[k + 1] * greenTint / 255f;
                var blue  = pixelBuffer[k + 2] * blueTint  / 255f;
                var alpha = pixelBuffer[k + 3] * alphaTint / 255f;

                if (pixelBuffer[k] == 0 && pixelBuffer[k + 1] == 0 && pixelBuffer[k + 2] == 0) {
                    alpha = 0;
                }

                if (blue > 255) {
                    blue = 255;
                }
                
                if (green > 255) {
                    green = 255;
                }

                if (red > 255) {
                    red = 255;
                }

                if (alpha > 255) {
                    alpha = 255;
                }

                pixelBuffer[k]     = (byte)red;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)blue;
                pixelBuffer[k + 3] = (byte)alpha;
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }
}