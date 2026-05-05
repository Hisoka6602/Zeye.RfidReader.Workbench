using Zeye.RfidReader.Workbench.Application.Options;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Devices;
using Zeye.RfidReader.Workbench.Contracts.Enums.Devices;

namespace Zeye.RfidReader.Workbench.Infrastructure.Drivers.Abstractions;

/// <summary>
/// RFID 读码器驱动描述信息。
/// </summary>
public sealed record class RfidReaderDriverDescriptor
{
    /// <summary>
    /// 厂商类型。
    /// </summary>
    public required RfidReaderVendorType VendorType { get; init; }

    /// <summary>
    /// 协议类型。
    /// </summary>
    public required RfidReaderProtocolType ProtocolType { get; init; }

    /// <summary>
    /// 显示名称。
    /// </summary>
    public required string DisplayName { get; init; }

    /// <summary>
    /// 会话创建函数。
    /// </summary>
    public required Func<IServiceProvider, RfidReaderDeviceOptions, IRfidReaderSession> CreateSession { get; init; }
}
