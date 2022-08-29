using System.Linq;
using System.Reactive.Disposables;
using ReactiveUI;
using Satyre.ActionPropertyViewModels;
using Satyre.Actions;

namespace Satyre.Wpf.Actions;

/// <summary>
/// Interaction logic for KeepSameAction.xaml
/// </summary>
public partial class BlurAction
{
  public BlurAction()
  {
    InitializeComponent();

    this.WhenActivated(disposable =>
    {
      ViewModel = (BlurActionViewModel)DataContext;

      this.OneWayBind(ViewModel,
          model => model.Name,
          view => view.TitleTextBlock.Text)
        .DisposeWith(disposable);

      this.BindCommand(ViewModel,
          model => model.RemoveAction,
          view => view.RemoveActionButton)
        .DisposeWith(disposable);

      this.BindCommand(ViewModel,
          model => model.MoveActionUp,
          view => view.MoveActionUpButton)
        .DisposeWith(disposable);

      this.BindCommand(ViewModel,
          model => model.MoveActionDown,
          view => view.MoveActionDownButton)
        .DisposeWith(disposable);

      this.OneWayBind(ViewModel,
          model => model.Properties,
          view => view.PropertiesListView.ItemsSource)
        .DisposeWith(disposable);
    });
  }
}