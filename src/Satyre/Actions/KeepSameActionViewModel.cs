using Satyre.ActionPropertyViewModels;
using Satyre.ViewModels;

namespace Satyre.Actions;

public class KeepSameActionViewModel : ImageActionViewModel
{
  public override void Act(ref IImageWrapper image)
  {
  }

  public override string Name => "Keep Same";
  public override string Description => "Keeps the Image the Same";
  public override string ErrorMessage => "";
  public override List<ActionPropertyViewModel> Properties { get; } = new();
}