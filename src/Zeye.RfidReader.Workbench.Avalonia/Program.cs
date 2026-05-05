using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using System;
using Zeye.RfidReader.Workbench.Application.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.DependencyInjection;
using Zeye.RfidReader.Workbench.Infrastructure.DependencyInjection;

namespace Zeye.RfidReader.Workbench.Avalonia;

internal static class Program
{
    internal static IServiceProvider Services { get; } = CreateServiceProvider();

    [STAThread]
    private static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
    }

    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddRfidReaderWorkbenchApplication();
        services.AddRfidReaderWorkbenchInfrastructure();
        services.AddRfidReaderWorkbenchAvalonia();
        return services.BuildServiceProvider();
    }
}
