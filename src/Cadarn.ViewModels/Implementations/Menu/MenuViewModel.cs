using System.Windows.Input;
using Cadarn.ViewModels.Interfaces;

namespace Cadarn.ViewModels.Implementations.Menu;

public class MenuViewModel : ViewModelBase, IMenuViewModel
{
    public ICommand ExitCommand { get; }

    public ICommand AboutCommand { get; }

    public ICommand OpenSettingsCommand { get; }
}