using ReactiveUI;

namespace Satyre.ViewModels;

public class ProcessedFeedViewModel : ReactiveObject
{
  private readonly ObservableAsPropertyHelper<IImageWrapper> _backingLiveImage;

  public ProcessedFeedViewModel(IProcessedFeedService processedFeedService)
  {
    _backingLiveImage = processedFeedService
      .ProcessedFeed
      .ToProperty(this, vm => vm.LiveImage, scheduler: RxApp.MainThreadScheduler);
  }

  public IImageWrapper LiveImage => _backingLiveImage.Value;
}