using Cadarn.ViewModels.Interfaces;

namespace Cadarn.ViewModels.Implementations;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    
    public IMenuViewModel MenuViewModel { get; }

    public MainWindowViewModel(
        IMenuViewModel menuViewModel)
    {

        MenuViewModel = menuViewModel;
    }
}