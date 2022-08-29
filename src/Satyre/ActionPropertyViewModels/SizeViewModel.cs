using System.Drawing;
using System.Reactive.Disposables;
using ReactiveUI;

namespace Satyre.ActionPropertyViewModels;

public class SizeViewModel : ActionPropertyViewModel
{
  private double _backingWidth;
  private double _backingHeight;
  private Size _backingSize;

  public SizeViewModel()
  {
    Name = "Size";
    this
      .WhenAnyValue(model => model.Width, model => model.Height)
      .Subscribe(tuple =>
      {
        _backingSize = new Size((int)tuple.Item1, (int)tuple.Item2);
      })
      .DisposeWith(Disposable);
  }

  public Size Size => _backingSize;
  public double Width
  {
    get => _backingWidth;
    set => this.RaiseAndSetIfChanged(ref _backingWidth, value);
  }

  public double Height
  {
    get => _backingHeight;
    set => this.RaiseAndSetIfChanged(ref _backingHeight, value);
  }

  public override string Name { get; }
}