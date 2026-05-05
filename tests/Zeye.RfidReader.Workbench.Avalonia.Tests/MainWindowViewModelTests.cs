using Xunit;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Tests;

/// <summary>
/// 主窗口视图模型测试。
/// </summary>
public sealed class MainWindowViewModelTests
{
    /// <summary>
    /// 启动命令可以更新运行状态。
    /// </summary>
    [Fact]
    public async Task StartReadingCommand_ShouldUpdateRunningState()
    {
        var viewModel = new MainWindowViewModel();

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
        var viewModel = new MainWindowViewModel();
        await viewModel.StartReadingCommand.ExecuteAsync(null);

        await viewModel.StopReadingCommand.ExecuteAsync(null);

        Assert.False(viewModel.IsRunning);
        Assert.Equal("读码已停止", viewModel.StatusText);
    }
}
