using DryIoc;
using ReactiveUI;
using Satyre.ViewModels;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : IViewFor<MainWindowViewModel>
{
  public MainWindow()
  {
    InitializeComponent();
    ViewModel = SatyreContainerProvider.Container.Resolve<MainWindowViewModel>();
    DataContext = ViewModel;
  }

  object IViewFor.ViewModel
  {
    get => ViewModel;
    set => ViewModel = (MainWindowViewModel)value;
  }

  public MainWindowViewModel ViewModel { get; set; }
}