namespace Zeye.RfidReader.Workbench.Domain.Tags;

/// <summary>
/// RFID 标签信息。
/// </summary>
public sealed record class RfidTag
{
    /// <summary>
    /// EPC 编码。
    /// </summary>
    public required string Epc { get; init; }

    /// <summary>
    /// TID 编码。
    /// </summary>
    public string? Tid { get; init; }

    /// <summary>
    /// 用户区数据。
    /// </summary>
    public string? UserData { get; init; }
}
