using System.Reactive.Disposables;
using ReactiveUI;
using Satyre.ActionPropertyViewModels;

namespace Satyre.Wpf.ActionProperties;

/// <summary>
/// Interaction logic for SizeProperty.xaml
/// </summary>
public partial class SizeProperty
{
  public SizeProperty()
  {
    InitializeComponent();

    this.WhenActivated(disposable =>
    {
      ViewModel = (SizeViewModel)DataContext;

      this.OneWayBind(ViewModel,
          model => model.Name,
          view => view.TitleTextBlock.Text)
        .DisposeWith(disposable);

      this.Bind(ViewModel,
          model => model.Width,
          view => view.WidthNumericUpDown.Value)
        .DisposeWith(disposable);

      this.Bind(ViewModel,
          model => model.Height,
          view => view.HeightNumericUpDown.Value)
        .DisposeWith(disposable);
    });
  }
}