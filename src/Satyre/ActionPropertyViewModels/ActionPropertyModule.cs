using DryIoc;

namespace Satyre.ActionPropertyViewModels;

public class ActionPropertyModule : IModule
{
  public void LoadBindings(ref IContainer container)
  {
    container.Register<PointViewModel>(Reuse.Transient, setup: Setup.With(allowDisposableTransient: true));
    container.Register<SizeViewModel>(Reuse.Transient, setup: Setup.With(allowDisposableTransient: true));
  }

  public void UnLoadBindings(ref IContainer container)
  {
    container.Unregister<PointViewModel>();
    container.Unregister<SizeViewModel>();
  }
}