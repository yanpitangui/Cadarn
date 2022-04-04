using AvaloniaStyles = Avalonia.Styling.Styles;
using Avalonia.Markup.Xaml;

namespace Cadarn.Styles.Themes;

public partial class LightTheme : AvaloniaStyles
{
    public LightTheme()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}