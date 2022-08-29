
namespace Satyre;

public interface ICaptureDeviceFactory
{
  public ICaptureDevices Create(int key);
}

internal class CaptureDeviceFactory : ICaptureDeviceFactory
{

  public ICaptureDevices Create(int key)
  {
    return new CaptureDevice(key);
  }
}