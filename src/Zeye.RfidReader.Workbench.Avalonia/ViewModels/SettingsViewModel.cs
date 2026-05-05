namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 设置页面视图模型。
/// </summary>
public sealed class SettingsViewModel : ViewModelBase
{
    /// <summary>
    /// 页面标题。
    /// </summary>
    public string Title { get; } = "系统设置";

    /// <summary>
    /// 页面说明。
    /// </summary>
    public string Description { get; } = "当前阶段仅提供 UI 占位，后续接入配置编辑能力。";
}
