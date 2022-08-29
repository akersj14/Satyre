using DryIoc;

namespace Satyre;

public interface IModule
{
  public void LoadBindings(ref IContainer container);
  public void UnLoadBindings(ref IContainer container);
}