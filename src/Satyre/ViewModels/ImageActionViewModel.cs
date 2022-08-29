using System.Reactive;
using ReactiveUI;
using Satyre.ActionPropertyViewModels;
using Satyre.Basic;

namespace Satyre.ViewModels;

public abstract class ImageActionViewModel : BasicReactiveDisposable
{
  protected ImageActionViewModel()
  {
    var actionsReporter = (IImageActionsReporter)SatyreContainerProvider.Container.GetService(typeof(IImageActionsReporter));
    if (actionsReporter == null)
      throw new ArgumentNullException(nameof(actionsReporter));

    RemoveAction = ReactiveCommand.Create(() =>
    {
      actionsReporter.RemoveImageAction(this);
      Dispose();
    });

    MoveActionUp = ReactiveCommand.Create(() => actionsReporter.MoveImageActionUp(this));
    MoveActionDown = ReactiveCommand.Create(() => actionsReporter.MoveImageActionDown(this));
  }

  public ReactiveCommand<Unit, Unit> RemoveAction { get; }
  public ReactiveCommand<Unit, Unit> MoveActionUp { get; }
  public ReactiveCommand<Unit, Unit> MoveActionDown { get; }
  public virtual void Act(ref IImageWrapper image) { }
  public virtual string Name => "None";
  public virtual string Description => "";
  public int Id { get; set; }
  public virtual string ErrorMessage => "";
  public bool HasError = false;
  public virtual List<ActionPropertyViewModel> Properties { get; }
}