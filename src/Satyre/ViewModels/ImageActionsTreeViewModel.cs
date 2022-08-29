using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using DynamicData;
using Satyre.Basic;

namespace Satyre.ViewModels;

public class ImageActionsTreeViewModel : BasicReactiveDisposable
{
  private readonly SourceList<ImageActionViewModel> _backingImageActions = new();
  public ImageActionsTreeViewModel(IImageActionsReporter imageActionsReporter)
  {
    _backingImageActions
      .Connect()
      .Bind(out ImageActions)
      .Subscribe()
      .DisposeWith(Disposable);

    imageActionsReporter
      .ImageActionAdded
      .Subscribe(action => _backingImageActions.Add(action))
      .DisposeWith(Disposable);

    imageActionsReporter
      .ImageActionRemoved
      .Subscribe(action => _backingImageActions.Remove(action))
      .DisposeWith(Disposable);

    imageActionsReporter
      .ImageActionMovedUp
      .Subscribe(action =>
      {
        var startingIndex = _backingImageActions.Items.IndexOf(action);
        if (startingIndex == -1 || startingIndex == _backingImageActions.Count - 1)
          return;
        _backingImageActions.Move(startingIndex, startingIndex + 1);
      })
      .DisposeWith(Disposable);

    imageActionsReporter
      .ImageActionMovedDown
      .Subscribe(action =>
      {
        var startingIndex = _backingImageActions.Items.IndexOf(action);
        if (startingIndex is -1 or 0)
          return;
        _backingImageActions.Move(startingIndex, startingIndex - 1);
      })
      .DisposeWith(Disposable);
  }

  public ReadOnlyObservableCollection<ImageActionViewModel> ImageActions;
}