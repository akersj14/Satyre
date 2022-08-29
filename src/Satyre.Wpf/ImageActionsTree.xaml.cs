using System.Reactive.Disposables;
using DryIoc;
using ReactiveUI;
using Satyre.ViewModels;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for ImageActionsTree.xaml
/// </summary>
public partial class ImageActionsTree
{
  public ImageActionsTree()
  {
    InitializeComponent();
    ViewModel = SatyreContainerProvider.Container.Resolve<ImageActionsTreeViewModel>();
    DataContext = ViewModel;

    this.WhenActivated(disposable =>
    {
      this.OneWayBind(ViewModel,
          model => model.ImageActions,
          view => view.ActionsListView.ItemsSource)
        .DisposeWith(disposable);
    });
  }
}