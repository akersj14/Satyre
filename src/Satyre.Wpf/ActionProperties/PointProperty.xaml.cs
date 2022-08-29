using System.Reactive.Disposables;
using ReactiveUI;
using Satyre.ActionPropertyViewModels;

namespace Satyre.Wpf.ActionProperties;

/// <summary>
/// Interaction logic for PointProperty.xaml
/// </summary>
public partial class PointProperty
{
  public PointProperty()
  {
    InitializeComponent();

    this.WhenActivated(disposable =>
    {
      ViewModel = (PointViewModel)DataContext;

      this.OneWayBind(ViewModel,
          model => model.Name,
          view => view.TitleTextBlock.Text)
        .DisposeWith(disposable);

      this.Bind(ViewModel,
          model => model.X,
          view => view.XNumericUpDown.Value)
        .DisposeWith(disposable);

      this.Bind(ViewModel,
          model => model.Y,
          view => view.YNumericUpDown.Value)
        .DisposeWith(disposable);
    });
  }
}