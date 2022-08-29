using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Satyre.ViewModels;

public interface IImageActionsReporter
{
  IObservable<ImageActionViewModel> ImageActionAdded { get; }
  IObservable<ImageActionViewModel> ImageActionRemoved { get; }
  IObservable<ImageActionViewModel> ImageActionMovedUp { get; }
  IObservable<ImageActionViewModel> ImageActionMovedDown { get; }

  void AddImageAction(ImageActionViewModel action);
  void RemoveImageAction(ImageActionViewModel action);
  void MoveImageActionUp(ImageActionViewModel action);
  void MoveImageActionDown(ImageActionViewModel action);
}

internal class ImageActionsReporter : IImageActionsReporter
{
  private readonly Subject<ImageActionViewModel> _backingImageActionAdded = new();
  private readonly Subject<ImageActionViewModel> _backingImageActionRemoved = new();
  private readonly Subject<ImageActionViewModel> _backingImageActionMovedUp = new();
  private readonly Subject<ImageActionViewModel> _backingImageActionMovedDown = new();

  public ImageActionsReporter()
  {
    ImageActionAdded = _backingImageActionAdded.AsObservable();
    ImageActionRemoved = _backingImageActionRemoved.AsObservable();
    ImageActionMovedDown = _backingImageActionMovedDown.AsObservable();
    ImageActionMovedUp = _backingImageActionMovedUp.AsObservable();
  }

  public IObservable<ImageActionViewModel> ImageActionAdded { get; }
  public IObservable<ImageActionViewModel> ImageActionRemoved { get; }
  public IObservable<ImageActionViewModel> ImageActionMovedUp { get; }
  public IObservable<ImageActionViewModel> ImageActionMovedDown { get; }
  public void AddImageAction(ImageActionViewModel action)
  {
    _backingImageActionAdded.OnNext(action);
  }

  public void RemoveImageAction(ImageActionViewModel action)
  {
    _backingImageActionRemoved.OnNext(action);
  }

  public void MoveImageActionUp(ImageActionViewModel action)
  {
    _backingImageActionMovedUp.OnNext(action);
  }

  public void MoveImageActionDown(ImageActionViewModel action)
  {
    _backingImageActionMovedDown.OnNext(action);
  }
}