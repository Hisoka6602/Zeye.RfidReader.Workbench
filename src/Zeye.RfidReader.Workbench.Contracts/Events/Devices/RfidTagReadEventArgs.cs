namespace Zeye.RfidReader.Workbench.Contracts.Events.Devices;

/// <summary>
/// RFID 标签读取事件载荷。
/// </summary>
public readonly record struct RfidTagReadEventArgs
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    public required string ReaderCode { get; init; }

    /// <summary>
    /// 天线编号。
    /// </summary>
    public required int AntennaId { get; init; }

    /// <summary>
    /// EPC 编码。
    /// </summary>
    public required string Epc { get; init; }

    /// <summary>
    /// TID 编码。
    /// </summary>
    public string? Tid { get; init; }

    /// <summary>
    /// RSSI 信号强度。
    /// </summary>
    public decimal? Rssi { get; init; }

    /// <summary>
    /// 本地读取时间。
    /// </summary>
    public required DateTime ReadTimeLocal { get; init; }
}
