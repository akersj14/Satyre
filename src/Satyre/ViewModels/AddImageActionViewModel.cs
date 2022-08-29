namespace Satyre.ViewModels;

public class AddImageActionViewModel
{
  public AddImageActionViewModel(IAddableImageActionViewModelFactory addableImageActionViewModelFactory)
  {
    AdditionalActions = typeof(ImageActionViewModel)
     .Assembly
     .GetTypes()
     .Where(type => type.IsAssignableTo(typeof(ImageActionViewModel)) && type.IsClass && !type.IsAbstract && !type.IsInterface)
     .Select(addableImageActionViewModelFactory.Create)
     .ToList();
  }

  public List<AddableActionViewModel> AdditionalActions { get; }
}