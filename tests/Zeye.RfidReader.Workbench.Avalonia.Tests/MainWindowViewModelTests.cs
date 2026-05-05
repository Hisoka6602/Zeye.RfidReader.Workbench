using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zeye.RfidReader.Workbench.Avalonia.Services;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Tests;

/// <summary>
/// 主窗口视图模型测试。
/// </summary>
public sealed class MainWindowViewModelTests
{
    /// <summary>
    /// 默认导航应定位到仪表盘。
    /// </summary>
    [Fact]
    public void Constructor_ShouldNavigateToDashboardByDefault()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();

        Assert.IsType<DashboardViewModel>(viewModel.CurrentViewModel);
    }

    /// <summary>
    /// 导航命令应切换到读码器监控页面。
    /// </summary>
    [Fact]
    public void NavigateCommand_ShouldSwitchToReaderMonitor()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();

        viewModel.NavigateCommand.Execute(PageKeys.ReaderMonitor);

        Assert.IsType<ReaderMonitorViewModel>(viewModel.CurrentViewModel);
    }

    /// <summary>
    /// 启动命令可以更新运行状态。
    /// </summary>
    [Fact]
    public async Task StartReadingCommand_ShouldUpdateRunningState()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();

        await viewModel.StartReadingCommand.ExecuteAsync(null);

        Assert.True(viewModel.IsRunning);
        Assert.Equal("读码已启动", viewModel.StatusText);
    }

    /// <summary>
    /// 停止命令可以更新运行状态。
    /// </summary>
    [Fact]
    public async Task StopReadingCommand_ShouldUpdateRunningState()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();
        await viewModel.StartReadingCommand.ExecuteAsync(null);

        await viewModel.StopReadingCommand.ExecuteAsync(null);

        Assert.False(viewModel.IsRunning);
        Assert.Equal("读码已停止", viewModel.StatusText);
    }

    /// <summary>
    /// 释放后不应继续响应导航事件。
    /// </summary>
    [Fact]
    public void Dispose_ShouldUnsubscribeFromNavigationService()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var navigationService = serviceProvider.GetRequiredService<IAppNavigationService>();
        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();

        viewModel.Dispose();
        navigationService.NavigateTo(PageKeys.ReaderMonitor);

        Assert.IsType<DashboardViewModel>(viewModel.CurrentViewModel);
    }
}
