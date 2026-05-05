namespace Zeye.RfidReader.Workbench.Domain.Events;

/// <summary>
/// RFID 读码器故障事件载荷。
/// </summary>
public readonly record struct RfidReaderFaultedEventArgs
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    public required string ReaderCode { get; init; }

    /// <summary>
    /// 故障消息。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// 本地故障时间。
    /// </summary>
    public required DateTime FaultedTimeLocal { get; init; }

    /// <summary>
    /// 异常对象。
    /// </summary>
    public Exception? Exception { get; init; }
}
