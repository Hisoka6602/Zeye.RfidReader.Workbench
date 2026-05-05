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
}
