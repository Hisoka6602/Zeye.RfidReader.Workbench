namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 主窗口视图模型。
/// </summary>
public sealed record class MainWindowViewModel
{
    /// <summary>
    /// 标题文本。
    /// </summary>
    public string Title { get; init; } = "Zeye RFID Reader Workbench";

    /// <summary>
    /// 主页说明文本。
    /// </summary>
    public string Subtitle { get; init; } = "当前演示界面展示 CI 门禁、契约迁移结果与 Lottie 动画占位。";

    /// <summary>
    /// 状态提示文本。
    /// </summary>
    public string StatusText { get; init; } = "已接入 Avalonia 12.0.2 对应的 Lottie 资源，后续可绑定实际设备状态。";
}
