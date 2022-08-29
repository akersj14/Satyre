using DryIoc;
using Satyre.ActionPropertyViewModels;
using Satyre.Actions;
using Satyre.ViewModels;

namespace Satyre;

public static class SatyreContainerProvider
{
  static SatyreContainerProvider()
  {
    IContainer container = new Container();
    container.Register<MainWindowViewModel>(Reuse.Singleton);
    container.Register<IEntryPoint, EntryPoint>(Reuse.Singleton);
    container.Register<LiveFeedViewModel>(Reuse.Singleton);
    container.Register<ProcessedFeedViewModel>(Reuse.Singleton);
    container.Register<ImageActionsTreeViewModel>(Reuse.Singleton);
    container.Register<AddImageActionViewModel>(Reuse.Singleton);
    container.Register<IImageWrapperFactory, MatWrapperFactory>(Reuse.Singleton);
    container.Register<ICaptureDeviceFactory, CaptureDeviceFactory>(Reuse.Singleton);
    container.Register<IVideoService, VideoService>(Reuse.Singleton);
    container.Register<IProcessedFeedService, ProcessedFeedService>(Reuse.Singleton);
    container.Register<IAddableImageActionViewModelFactory, AddableImageActionViewModelFactory>(Reuse.Singleton);
    container.Register<IImageActionsReporter, ImageActionsReporter>(Reuse.Singleton);

    new ActionsModule().LoadBindings(ref container);
    new ActionPropertyModule().LoadBindings(ref container);
    Container = container;
  }
  public static IContainer Container { get; }
}