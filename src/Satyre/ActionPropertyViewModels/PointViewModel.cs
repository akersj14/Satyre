using System.Drawing;
using System.Reactive.Disposables;
using ReactiveUI;
using Satyre.Basic;

namespace Satyre.ActionPropertyViewModels;

public class PointViewModel : ActionPropertyViewModel
{
  private double _backingX;
  private double _backingY;
  private Point _backingPoint;

  public PointViewModel()
  {
    Name = "Point";
    this.WhenAnyValue(model => model.X, model => model.Y)
      .Subscribe(tuple => _backingPoint = new Point((int)tuple.Item1, (int)tuple.Item2))
      .DisposeWith(Disposable);
  }

  public double X
  {
    get => _backingX;
    set => this.RaiseAndSetIfChanged(ref _backingX, value);
  }
  public double Y
  {
    get => _backingY;
    set => this.RaiseAndSetIfChanged(ref _backingY, value);
  }
  public Point Point
  {
    get => _backingPoint;
    set => this.RaiseAndSetIfChanged(ref _backingPoint, value);
  }

  public override string Name { get; }
}