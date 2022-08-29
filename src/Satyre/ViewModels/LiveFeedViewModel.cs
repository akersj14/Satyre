using System.Reactive.Disposables;
using ReactiveUI;

namespace Satyre.ViewModels;

public class LiveFeedViewModel : ReactiveObject, IDisposable
{
  private readonly ObservableAsPropertyHelper<IImageWrapper> _backingLiveFeed;
  private readonly CompositeDisposable _compositeDisposable = new();
  public LiveFeedViewModel(IVideoService videoService)
  {
    if (videoService == null)
      throw new ArgumentNullException(nameof(videoService));
    _backingLiveFeed = videoService
      .SourceImage
      .ToProperty(this, model => model.LiveImage, scheduler: RxApp.MainThreadScheduler);
  }

  public IImageWrapper LiveImage => _backingLiveFeed.Value;
  public void Dispose()
  {
    _compositeDisposable.Dispose();
    _backingLiveFeed.Dispose();
  }
}