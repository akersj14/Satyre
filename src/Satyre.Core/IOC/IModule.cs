namespace Satyre.Core.IOC;

public interface IModule
{
  public void LoadBindings();
  public void UnloadBindings();
}