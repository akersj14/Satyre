using System.Reactive.Disposables;

namespace Satyre.Basic;

public abstract class BasicDisposable : IDisposable
{
  protected CompositeDisposable Disposable = new();
  public void Dispose()
  {
    Disposable.Dispose();
  }
}