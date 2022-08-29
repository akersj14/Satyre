using Emgu.CV;

namespace Satyre;

public interface IImageWrapperFactory
{
  IImageWrapper Create();
}

internal class MatWrapperFactory : IImageWrapperFactory
{
  public IImageWrapper Create()
  {
    return new MatWrapper(new Mat());
  }
}