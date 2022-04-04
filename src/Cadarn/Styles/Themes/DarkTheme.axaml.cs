using Avalonia.Markup.Xaml;
using AvaloniaStyles = Avalonia.Styling.Styles;


namespace Cadarn.Styles.Themes;

public partial class DarkTheme : AvaloniaStyles
{
    public DarkTheme()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}