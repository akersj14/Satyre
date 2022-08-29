using System.Reactive.Disposables;
using ReactiveUI;

namespace Satyre.Wpf.Actions;

/// <summary>
/// Interaction logic for KeepSameAction.xaml
/// </summary>
public partial class KeepSameAction
{
  public KeepSameAction()
  {
    InitializeComponent();

    this.WhenActivated(disposable =>
    {
      ViewModel = (Satyre.Actions.KeepSameActionViewModel)DataContext;

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
    });
  }
}