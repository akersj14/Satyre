using Satyre.Basic;

namespace Satyre.ActionPropertyViewModels;

public abstract class ActionPropertyViewModel : BasicReactiveDisposable
{
  public abstract string Name { get; }
}