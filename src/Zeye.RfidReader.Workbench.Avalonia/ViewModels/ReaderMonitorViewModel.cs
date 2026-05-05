namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 读码器监控视图模型。
/// </summary>
public sealed class ReaderMonitorViewModel : ViewModelBase
{
    /// <summary>
    /// 页面标题。
    /// </summary>
    public string Title { get; } = "读码器监控";

    /// <summary>
    /// 页面说明。
    /// </summary>
    public string Description { get; } = "当前阶段仅提供 UI 占位，后续接入 Application 层设备状态。";
}
