using ReactiveUI;
using System.Reactive.Disposables;
using DryIoc;
using Satyre.ViewModels;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for UserControl1.xaml
/// </summary>
public partial class LiveFeed
{
  public LiveFeed()
  {
    InitializeComponent();
    ViewModel = SatyreContainerProvider.Container.Resolve<LiveFeedViewModel>();
    DataContext = ViewModel;

    this.WhenActivated(disposable =>
    {
      this.OneWayBind(ViewModel,
          model => model.LiveImage,
          feed => feed.OriginalImage.Source,
          Conversions.ImageWrapperToBitmapImage)
        .DisposeWith(disposable);
    });
  }
}