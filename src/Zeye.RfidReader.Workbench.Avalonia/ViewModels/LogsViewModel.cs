namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 日志页面视图模型。
/// </summary>
public sealed class LogsViewModel : ViewModelBase
{
    /// <summary>
    /// 页面标题。
    /// </summary>
    public string Title { get; } = "运行日志";

    /// <summary>
    /// 页面说明。
    /// </summary>
    public string Description { get; } = "当前阶段仅提供 UI 占位，后续接入 NLog 日志查看能力。";
}
