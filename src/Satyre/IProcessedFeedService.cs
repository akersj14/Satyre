using System.Reactive.Linq;
using DynamicData;
using Satyre.ViewModels;
using MoreLinq;
namespace Satyre;

/// <summary>
/// Provides the Processed Feed and the actions
/// actively being used
/// </summary>
public interface IProcessedFeedService
{
  IObservable<IImageWrapper> ProcessedFeed { get; }
}

/// <inheritdoc cref="IProcessedFeedService"/>
internal class ProcessedFeedService : IProcessedFeedService
{
  public ProcessedFeedService(IVideoService videoService, ImageActionsTreeViewModel imageActionsTreeViewModel)
  {
    if (videoService == null)
      throw new ArgumentNullException(nameof(videoService));
    if (imageActionsTreeViewModel == null)
      throw new ArgumentNullException(nameof(imageActionsTreeViewModel));

    ProcessedFeed = videoService
      .SourceImage
      .Select(image =>
      {
        imageActionsTreeViewModel
          .ImageActions
          .ForEach(action => action.Act(ref image));
        return image;
      });
  }
  public IObservable<IImageWrapper> ProcessedFeed { get; }
}