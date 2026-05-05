namespace Zeye.RfidReader.Workbench.Avalonia.Models;

/// <summary>
/// 读码器状态卡片显示模型。
/// </summary>
public sealed record class ReaderStatusCardModel
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    public required string ReaderCode { get; init; }

    /// <summary>
    /// 读码器名称。
    /// </summary>
    public required string ReaderName { get; init; }

    /// <summary>
    /// 状态文本。
    /// </summary>
    public required string StatusText { get; init; }

    /// <summary>
    /// 是否在线。
    /// </summary>
    public bool IsOnline { get; init; }
}
