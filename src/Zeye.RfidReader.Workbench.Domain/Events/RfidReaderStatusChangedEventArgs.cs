using Zeye.RfidReader.Workbench.Domain.Devices;

namespace Zeye.RfidReader.Workbench.Domain.Events;

/// <summary>
/// RFID 读码器状态变更事件载荷。
/// </summary>
public readonly record struct RfidReaderStatusChangedEventArgs
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    public required string ReaderCode { get; init; }

    /// <summary>
    /// 当前连接状态。
    /// </summary>
    public required RfidReaderConnectionState ConnectionState { get; init; }

    /// <summary>
    /// 本地变更时间。
    /// </summary>
    public required DateTime ChangedTimeLocal { get; init; }

    /// <summary>
    /// 状态消息。
    /// </summary>
    public string? Message { get; init; }
}
