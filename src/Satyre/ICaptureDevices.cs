namespace Satyre;

public interface ICaptureDevices: IDisposable
{
  public int Key { get; }
  IObservable<IImageWrapper> Feed { get; set; }
  public bool IsAvailable { get; }
  void Start();
  void Stop();
}