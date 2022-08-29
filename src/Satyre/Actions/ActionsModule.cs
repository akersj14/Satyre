using DryIoc;

namespace Satyre.Actions;

public class ActionsModule : IModule
{
  public void LoadBindings(ref IContainer container)
  {
    container.Register<BlurActionViewModel>(Reuse.Transient, setup: Setup.With(allowDisposableTransient: true));
    container.Register<KeepSameActionViewModel>(Reuse.Transient, setup: Setup.With(allowDisposableTransient: true));
  }

  public void UnLoadBindings(ref IContainer container)
  {
    container.Unregister<BlurActionViewModel>();
    container.Unregister<KeepSameActionViewModel>();
  }
}