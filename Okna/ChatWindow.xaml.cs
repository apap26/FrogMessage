using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyApp
{
    public class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}