namespace Satyre.ViewModels;

public interface IAddableImageActionViewModelFactory
{
  AddableActionViewModel Create(Type imageActionType);
}

internal class AddableImageActionViewModelFactory : IAddableImageActionViewModelFactory
{
  private readonly IImageActionsReporter _imageActionReporter;

  public AddableImageActionViewModelFactory(IImageActionsReporter imageActionReporter)
  {
    _imageActionReporter = imageActionReporter ?? throw new ArgumentNullException(nameof(imageActionReporter));
  }

  public AddableActionViewModel Create(Type imageActionType)
  {
    return new AddableActionViewModel(_imageActionReporter, imageActionType);
  }
}