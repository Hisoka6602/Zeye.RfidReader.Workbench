using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.Services;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;
using Zeye.RfidReader.Workbench.Avalonia.Views;

namespace Zeye.RfidReader.Workbench.Avalonia.DependencyInjection;

/// <summary>
/// Avalonia 层服务注册扩展。
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 注册 RFID 读码器工作台 Avalonia 层服务。
    /// </summary>
    /// <param name="services">服务集合。</param>
    /// <returns>服务集合。</returns>
    public static IServiceCollection AddRfidReaderWorkbenchAvalonia(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IAppNavigationService, AppNavigationService>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IToastNotificationService, ToastNotificationService>();
        services.AddSingleton<IUiDispatcher, AvaloniaUiDispatcher>();

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<ReaderMonitorViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<LogsViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<DashboardView>();
        services.AddTransient<ReaderMonitorView>();
        services.AddTransient<SettingsView>();
        services.AddTransient<LogsView>();

        return services;
    }
}
