using System.Reactive.Disposables;
using ReactiveUI;

namespace Satyre.Basic;

public abstract class BasicReactiveDisposable : ReactiveObject, IDisposable
{
  protected readonly CompositeDisposable Disposable = new();
  public void Dispose()
  {
    Disposable.Dispose();
  }
}