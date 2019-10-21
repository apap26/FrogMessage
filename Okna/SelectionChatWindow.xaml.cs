using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyApp
{
    public class SelectionChatWindow : Window
    {
        public SelectionChatWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}