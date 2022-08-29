using System.Reactive.Disposables;
using DryIoc;
using ReactiveUI;
using Satyre.ViewModels;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for UserControl1.xaml
/// </summary>
public partial class ProcessedFeed
{
  public ProcessedFeed()
  {
    InitializeComponent();
    ViewModel = SatyreContainerProvider.Container.Resolve<ProcessedFeedViewModel>();
    DataContext = ViewModel;

    this.WhenActivated(disposable =>
    {
      this.OneWayBind(ViewModel,
          model => model.LiveImage,
          feed => feed.SourceImage.Source,
          Conversions.ImageWrapperToBitmapImage)
        .DisposeWith(disposable);
    });
  }
}