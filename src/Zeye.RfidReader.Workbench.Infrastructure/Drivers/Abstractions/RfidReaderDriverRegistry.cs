using Zeye.RfidReader.Workbench.Contracts.Enums.Devices;

namespace Zeye.RfidReader.Workbench.Infrastructure.Drivers.Abstractions;

/// <summary>
/// RFID 读码器驱动注册表。
/// </summary>
public sealed class RfidReaderDriverRegistry
{
    private readonly Dictionary<(RfidReaderVendorType VendorType, RfidReaderProtocolType ProtocolType), RfidReaderDriverDescriptor> _descriptors = [];

    /// <summary>
    /// 注册 RFID 读码器驱动描述信息。
    /// </summary>
    /// <param name="descriptor">驱动描述信息。</param>
    public void Register(RfidReaderDriverDescriptor descriptor)
    {
        var key = (descriptor.VendorType, descriptor.ProtocolType);
        if (!_descriptors.TryAdd(key, descriptor))
        {
            throw new InvalidOperationException($"RFID 读码器驱动重复注册：厂商={descriptor.VendorType}，协议={descriptor.ProtocolType}");
        }
    }

    /// <summary>
    /// 获取必需的 RFID 读码器驱动描述信息。
    /// </summary>
    /// <param name="vendorType">厂商类型。</param>
    /// <param name="protocolType">协议类型。</param>
    /// <returns>驱动描述信息。</returns>
    public RfidReaderDriverDescriptor GetRequired(RfidReaderVendorType vendorType, RfidReaderProtocolType protocolType)
    {
        if (_descriptors.TryGetValue((vendorType, protocolType), out var descriptor))
        {
            return descriptor;
        }

        throw new InvalidOperationException($"未找到 RFID 读码器驱动：厂商={vendorType}，协议={protocolType}");
    }
}
