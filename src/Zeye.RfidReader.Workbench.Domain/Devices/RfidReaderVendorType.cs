using System.ComponentModel;

namespace Zeye.RfidReader.Workbench.Domain.Devices;

/// <summary>
/// RFID 读码器厂商类型。
/// </summary>
public enum RfidReaderVendorType
{
    /// <summary>
    /// 未指定厂商。
    /// </summary>
    [Description("未指定厂商")]
    Unknown = 0,

    /// <summary>
    /// 自定义协议设备。
    /// </summary>
    [Description("自定义协议设备")]
    Custom = 1,

    /// <summary>
    /// 模拟 RFID 设备。
    /// </summary>
    [Description("模拟RFID设备")]
    Simulated = 2,

    /// <summary>
    /// Chainway RFID 设备。
    /// </summary>
    [Description("Chainway RFID设备")]
    Chainway = 10,

    /// <summary>
    /// Impinj RFID 设备。
    /// </summary>
    [Description("Impinj RFID设备")]
    Impinj = 20,

    /// <summary>
    /// ThingMagic RFID 设备。
    /// </summary>
    [Description("ThingMagic RFID设备")]
    ThingMagic = 30,
}
