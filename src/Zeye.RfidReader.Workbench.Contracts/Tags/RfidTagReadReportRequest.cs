namespace Zeye.RfidReader.Workbench.Contracts.Tags;

/// <summary>
/// RFID 标签读取上报请求。
/// </summary>
public sealed record class RfidTagReadReportRequest
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
    /// 本地读取时间。
    /// </summary>
    public required DateTime ReadTimeLocal { get; init; }
}
