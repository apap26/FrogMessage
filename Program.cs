﻿using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using VkNet;

namespace MyApp
{
    
    class Program
    {
        VkApi api = new VkApi();
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            VkApi api = new VkApi();
            app.Run(new MainWindow(api));
        }
    }
}
