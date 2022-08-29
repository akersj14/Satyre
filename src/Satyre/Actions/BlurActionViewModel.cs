using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using Satyre.ActionPropertyViewModels;
using Satyre.ViewModels;

namespace Satyre.Actions;

public class BlurActionViewModel : ImageActionViewModel
{
  private string _backingErrorMessage = string.Empty;
  private readonly List<ActionPropertyViewModel> _backingProperties = new();

  public BlurActionViewModel(SizeViewModel size, PointViewModel anchor)
  {
    Size = size ?? throw new ArgumentNullException(nameof(size));
    Anchor = anchor ?? throw new ArgumentNullException(nameof(anchor));

    _backingProperties.Add(Size);
    _backingProperties.Add(Anchor);

    _backingProperties.ForEach(prop => prop.DisposeWith(Disposable));
  }

  public override void Act(ref IImageWrapper image)
  {
    _backingErrorMessage = image.Blur(Size.Size, Anchor.Point);
    HasError = !string.IsNullOrEmpty(_backingErrorMessage);
  }

  public SizeViewModel Size { get; }
  public PointViewModel Anchor { get; }
  public override string Name => "Blur";
  public override string Description => "";
  public override string ErrorMessage => _backingErrorMessage;
  public override List<ActionPropertyViewModel> Properties => _backingProperties;
}