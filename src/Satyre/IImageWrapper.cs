using System.Drawing;
using Emgu.CV;

namespace Satyre;

public interface IImageWrapper
{
  Bitmap ToBitmap();
  Mat ToMat();
  IImageWrapper UpdateWith(Mat queryFrame);
  string Blur(Size size, Point point);
}

internal class MatWrapper : IImageWrapper
{
  private Mat _mat;

  public MatWrapper(Mat queryFrame)
  {
    _mat = queryFrame;
  }

  public Bitmap ToBitmap()
  {
    return _mat.ToBitmap();
  }

  public Mat ToMat()
  {
    return _mat;
  }

  public IImageWrapper UpdateWith(Mat queryFrame)
  {
    _mat = queryFrame;
    return this;
  }

  public string Blur(Size size, Point point)
  {
    try
    {
      CvInvoke.Blur(_mat, _mat, size, point);
      return string.Empty;
    }
    catch (Exception)
    {
      return "Blur Failed";
    }
  }
}