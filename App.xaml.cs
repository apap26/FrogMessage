using Avalonia;
using Avalonia.Markup.Xaml;

namespace MyApp
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}