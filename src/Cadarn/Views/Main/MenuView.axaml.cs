using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Cadarn.Views.Main;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}