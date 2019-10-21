using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyApp
{
    public class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}