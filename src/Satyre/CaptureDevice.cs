using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Satyre;

public class CaptureDevice : ICaptureDevices
{
  private readonly VideoCapture _videoCapture;
  private readonly CompositeDisposable _streamingObservable = new();
  private readonly Subject<IImageWrapper> _backingImageWrapper = new();

  public CaptureDevice(int captureIndex)
  {
    Key = captureIndex;
    Feed = _backingImageWrapper.AsObservable();
    _videoCapture = new VideoCapture(captureIndex);
  }
  
  public int Key { get; }
  public IObservable<IImageWrapper> Feed { get; set; }
  public bool IsAvailable => _videoCapture.IsOpened;
  public void Start()
  {
    if (!_videoCapture.IsOpened)
      return;

    _videoCapture.Start();
    Observable.Interval(TimeSpan.FromMilliseconds(_videoCapture.Get(CapProp.Fps)))
      .Subscribe(_ =>
      {
        var queryFrame = _videoCapture.QueryFrame();
        if (queryFrame != null)
          _backingImageWrapper.OnNext(new MatWrapper(queryFrame));
      })
      .DisposeWith(_streamingObservable);
  }

  public void Stop()
  {
    _videoCapture.Stop();
    _streamingObservable.Clear();
  }

  public void Dispose()
  {
    _videoCapture.Dispose();
    _streamingObservable.Dispose();
    _backingImageWrapper.Dispose();
  }
}