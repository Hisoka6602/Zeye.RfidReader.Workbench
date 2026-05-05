using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zeye.RfidReader.Workbench.Avalonia.Services;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Tests;

/// <summary>
/// 应用导航服务测试。
/// </summary>
public sealed class AppNavigationServiceTests
{
    /// <summary>
    /// 未知页面键应抛出中文异常。
    /// </summary>
    [Fact]
    public void NavigateTo_ShouldThrowChineseException_WhenPageKeyIsUnknown()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var navigationService = serviceProvider.GetRequiredService<IAppNavigationService>();

        var exception = Assert.Throws<InvalidOperationException>(() => navigationService.NavigateTo("Unknown"));

        Assert.Equal("不支持的页面键：Unknown", exception.Message);
    }

    /// <summary>
    /// 读码器监控页面应成功解析。
    /// </summary>
    [Fact]
    public void NavigateTo_ShouldResolveReaderMonitorViewModel()
    {
        using var serviceProvider = TestServiceProviderFactory.Create();
        var navigationService = serviceProvider.GetRequiredService<IAppNavigationService>();

        navigationService.NavigateTo(PageKeys.ReaderMonitor);

        Assert.IsType<ReaderMonitorViewModel>(navigationService.CurrentViewModel);
    }
}
