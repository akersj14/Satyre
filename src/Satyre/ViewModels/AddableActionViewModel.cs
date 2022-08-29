using System.Reactive;
using Humanizer;
using ReactiveUI;

namespace Satyre.ViewModels;

public class AddableActionViewModel : ReactiveObject
{

  public AddableActionViewModel(IImageActionsReporter imageActionsReporter, Type imageActionType)
  {
    var fullName = imageActionType.Name;
    var indexOfViewModel = fullName.IndexOf("ViewModel");
    if (indexOfViewModel != -1)
      fullName = fullName.Remove(indexOfViewModel);

    Title = fullName.Humanize();
    AddAction = ReactiveCommand.Create(() =>
    {
      var imageAction = (ImageActionViewModel)SatyreContainerProvider.Container.GetService(imageActionType);
      imageActionsReporter.AddImageAction(imageAction);
    });
  }
  public string Title { get; }
  public ReactiveCommand<Unit, Unit> AddAction { get; }
}