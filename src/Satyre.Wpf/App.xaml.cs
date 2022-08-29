using System;
using System.Reactive.Disposables;
using System.Reflection;
using System.Windows;
using DryIoc;
using ReactiveUI;
using Splat;
using Splat.DryIoc;
using Splat.NLog;

namespace Satyre.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{

  private IDisposable _servicesDisposable = Disposable.Empty;
  protected override void OnStartup(StartupEventArgs e)
  {
    //Set RxUI's locator to Dry
    SatyreContainerProvider.Container.UseDryIocDependencyResolver();
    //Register Views
    Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
    //Register Logger
    Locator.CurrentMutable.UseNLogWithWrappingFullLogger();
    //Start Services
    _servicesDisposable = SatyreContainerProvider.Container.Resolve<IEntryPoint>();

    base.OnStartup(e);
  }
  protected override void OnExit(ExitEventArgs e)
  {
    _servicesDisposable.Dispose();
    base.OnExit(e);
  }
}