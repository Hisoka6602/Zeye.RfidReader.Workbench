namespace Zeye.RfidReader.Workbench.Avalonia.Models;

/// <summary>
/// 导航项显示模型。
/// </summary>
public sealed record class NavigationItemModel
{
    /// <summary>
    /// 导航项键。
    /// </summary>
    public required string Key { get; init; }

    /// <summary>
    /// 导航项标题。
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// 导航项说明。
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// 是否启用。
    /// </summary>
    public bool IsEnabled { get; init; } = true;
}
