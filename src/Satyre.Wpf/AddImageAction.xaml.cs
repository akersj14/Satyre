using System.Reactive.Disposables;
using ReactiveUI;
using Satyre.ViewModels;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for AddImageAction.xaml
/// </summary>
public partial class AddImageAction
{
  public AddImageAction()
  {
    InitializeComponent();
    ViewModel = (AddImageActionViewModel)SatyreContainerProvider.Container.GetService(typeof(AddImageActionViewModel));
    DataContext = ViewModel;

    this.WhenActivated(disposable =>
    {
      this.OneWayBind(ViewModel,
          model => model.AdditionalActions,
          view => view.AddActionContextMenu.ItemsSource)
        .DisposeWith(disposable);
    });
  }
}