using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Satyre.Wpf;

public static class Conversions
{
  public static BitmapImage ToBitmapImage(this Image bitmap)
  {
    using var memory = new MemoryStream();
    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
    memory.Position = 0;

    var bitmapImage = new BitmapImage();
    bitmapImage.BeginInit();
    bitmapImage.StreamSource = memory;
    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    bitmapImage.EndInit();
    bitmapImage.Freeze();

    return bitmapImage;
  }
  public static BitmapImage ImageWrapperToBitmapImage(IImageWrapper? imageWrapper)
  {
    return imageWrapper == null ? new BitmapImage() : imageWrapper.ToBitmap().ToBitmapImage();
  }
}