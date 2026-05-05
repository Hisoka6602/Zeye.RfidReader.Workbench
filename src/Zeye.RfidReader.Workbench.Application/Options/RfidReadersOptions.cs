namespace Zeye.RfidReader.Workbench.Application.Options;

/// <summary>
/// RFID 读码器集合配置。
/// </summary>
public sealed record class RfidReadersOptions
{
    /// <summary>
    /// 配置节点名称。
    /// </summary>
    public const string SectionName = "RfidReaders";

    /// <summary>
    /// 读码器设备配置集合。
    /// </summary>
    public IReadOnlyList<RfidReaderDeviceOptions> Devices { get; init; } = [];
}
