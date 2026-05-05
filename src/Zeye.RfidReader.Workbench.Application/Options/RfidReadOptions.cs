namespace Zeye.RfidReader.Workbench.Application.Options;

/// <summary>
/// RFID 读码配置。
/// </summary>
public sealed record class RfidReadOptions
{
    /// <summary>
    /// 去重窗口，单位为毫秒。
    /// </summary>
    public int DuplicateWindowMs { get; init; } = 500;

    /// <summary>
    /// 自动启动读码标记。
    /// </summary>
    public bool IsAutoStartEnabled { get; init; }

    /// <summary>
    /// 原始报文日志启用标记。
    /// </summary>
    public bool IsRawFrameLoggingEnabled { get; init; }
}
