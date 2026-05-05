using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.Bootstrap;
using Zeye.RfidReader.Workbench.Avalonia.Views;

namespace Zeye.RfidReader.Workbench.Avalonia;

/// <summary>
/// Avalonia 应用入口类型。
/// </summary>
public sealed partial class App : global::Avalonia.Application
{
    private ServiceProvider? _serviceProvider;

    /// <inheritdoc />
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <inheritdoc />
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _serviceProvider = AvaloniaServiceProviderFactory.Create();
            desktop.MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            desktop.Exit += OnDesktopExit;
        }

        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    /// 处理桌面应用退出流程。
    /// </summary>
    /// <param name="sender">事件发送方。</param>
    /// <param name="e">退出事件参数。</param>
    private void OnDesktopExit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        if (sender is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Exit -= OnDesktopExit;
        }

        _serviceProvider?.Dispose();
        _serviceProvider = null;
    }
}
