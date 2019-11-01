using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyApp
{
    public class ErrorWindow : Window
    {
        public TextBlock Text => this.FindControl<TextBlock>("Text");
        public Button BtnOk => this.FindControl<Button>("BtnOk");
        public ErrorWindow(string ErrorText)
        {
            InitializeComponent();
            Text.Text = ErrorText;
        }

        public void BtnOk_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            BtnOk.Click += BtnOk_Click;
        }
    }
}