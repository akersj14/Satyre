using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DynamicData;

namespace Satyre;

public interface IVideoService : IDisposable
{
  IObservable<IImageWrapper> SourceImage { get; }
  bool TrySettingCaptureDevice(int index);
  void RefreshAvailableCaptureDevices();
  IObservableCache<ICaptureDevices, int> AvailableCaptureDevices { get; }
}

public class VideoService : IVideoService
{
  private readonly ICaptureDeviceFactory _captureDeviceFactory;
  private ICaptureDevices _activeCaptureDevices;
  private readonly Subject<IImageWrapper> _backingLiveFeed = new();
  private readonly SourceCache<ICaptureDevices, int> _backingAvailableCaptureDevices = new(device => device.Key);
  private readonly CompositeDisposable _tempDisposable = new();

  public VideoService(ICaptureDeviceFactory captureDeviceFactory)
  {
    _captureDeviceFactory = captureDeviceFactory ?? throw new ArgumentNullException(nameof(captureDeviceFactory));
    AvailableCaptureDevices = _backingAvailableCaptureDevices.AsObservableCache();
    SourceImage = _backingLiveFeed.AsObservable();
    _activeCaptureDevices ??= new CaptureDevice(100);
    RefreshAvailableCaptureDevices();
    TrySettingCaptureDevice(0);
  }

  public bool TrySettingCaptureDevice(int index)
  {
    var optionalCaptureDevice = _backingAvailableCaptureDevices.Lookup(index);
    if (optionalCaptureDevice.HasValue)
    {
      _activeCaptureDevices.Stop();
      _tempDisposable.Clear();
      _activeCaptureDevices = optionalCaptureDevice.Value;
      _activeCaptureDevices
        .Feed
        .Subscribe(image => _backingLiveFeed.OnNext(image))
        .DisposeWith(_tempDisposable);
      _activeCaptureDevices.Start();
    }
    return true;
  }

  public void RefreshAvailableCaptureDevices()
  {
    var activeDeviceIndex = _activeCaptureDevices.Key;
    _activeCaptureDevices.Dispose();
    foreach (var captureDevices in _backingAvailableCaptureDevices.Items)
    {
      captureDevices.Dispose();
    }
    _backingAvailableCaptureDevices.Clear();
    var currentIndex = 0;
    var available = true;
    while (available)
    {
      var captureDevice = _captureDeviceFactory.Create(currentIndex);
      if (captureDevice.IsAvailable)
      {
        _backingAvailableCaptureDevices.AddOrUpdate(captureDevice);
        currentIndex++;
      }
      else
      {
        available = false;
      }
    }

    TrySettingCaptureDevice(activeDeviceIndex);
  }

  public IObservableCache<ICaptureDevices, int> AvailableCaptureDevices { get; }

  public IObservable<IImageWrapper> SourceImage { get; }
  
  public void Dispose()
  {
    _activeCaptureDevices.Dispose();
    _backingLiveFeed.Dispose();
    _tempDisposable.Dispose();
  }
}