using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// 应用导航服务。
/// </summary>
public sealed class AppNavigationService : IAppNavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private ViewModelBase? _currentViewModel;

    /// <summary>
    /// 初始化应用导航服务。
    /// </summary>
    /// <param name="serviceProvider">服务提供器。</param>
    public AppNavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public ViewModelBase? CurrentViewModel => _currentViewModel;

    /// <inheritdoc />
    public event EventHandler<ViewModelBase?>? CurrentViewModelChanged;

    /// <inheritdoc />
    public void NavigateTo(string pageKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(pageKey);

        ViewModelBase viewModel = pageKey switch
        {
            PageKeys.Dashboard => _serviceProvider.GetRequiredService<DashboardViewModel>(),
            PageKeys.ReaderMonitor => _serviceProvider.GetRequiredService<ReaderMonitorViewModel>(),
            PageKeys.Settings => _serviceProvider.GetRequiredService<SettingsViewModel>(),
            PageKeys.Logs => _serviceProvider.GetRequiredService<LogsViewModel>(),
            _ => throw new InvalidOperationException($"不支持的页面键：{pageKey}")
        };

        _currentViewModel = viewModel;
        CurrentViewModelChanged?.Invoke(this, _currentViewModel);
    }
}
