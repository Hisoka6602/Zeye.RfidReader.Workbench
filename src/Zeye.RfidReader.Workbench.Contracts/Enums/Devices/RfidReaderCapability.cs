using System.ComponentModel;

namespace Zeye.RfidReader.Workbench.Contracts.Enums.Devices;

/// <summary>
/// RFID 读码器能力标记。
/// </summary>
[Flags]
public enum RfidReaderCapability
{
    /// <summary>
    /// 无特殊能力。
    /// </summary>
    [Description("无特殊能力")]
    None = 0,

    /// <summary>
    /// 支持设置功率。
    /// </summary>
    [Description("支持设置功率")]
    CanSetPower = 1 << 0,

    /// <summary>
    /// 支持多天线。
    /// </summary>
    [Description("支持多天线")]
    CanUseMultipleAntennas = 1 << 1,

    /// <summary>
    /// 支持读取 TID。
    /// </summary>
    [Description("支持读取TID")]
    CanReadTid = 1 << 2,

    /// <summary>
    /// 支持读取 RSSI。
    /// </summary>
    [Description("支持读取RSSI")]
    CanReadRssi = 1 << 3,

    /// <summary>
    /// 支持 GPIO 控制。
    /// </summary>
    [Description("支持GPIO控制")]
    CanControlGpio = 1 << 4,

    /// <summary>
    /// 支持触发式读码。
    /// </summary>
    [Description("支持触发式读码")]
    CanUseTriggeredReading = 1 << 5,

    /// <summary>
    /// 支持连续盘点。
    /// </summary>
    [Description("支持连续盘点")]
    CanUseInventoryReading = 1 << 6,
}
