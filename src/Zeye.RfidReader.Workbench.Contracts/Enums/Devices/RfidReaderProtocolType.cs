using System.ComponentModel;

namespace Zeye.RfidReader.Workbench.Contracts.Enums.Devices;

/// <summary>
/// RFID 读码器通信协议类型。
/// </summary>
public enum RfidReaderProtocolType
{
    /// <summary>
    /// 未指定协议。
    /// </summary>
    [Description("未指定协议")]
    Unknown = 0,

    /// <summary>
    /// TCP 协议。
    /// </summary>
    [Description("TCP协议")]
    Tcp = 1,

    /// <summary>
    /// 串口协议。
    /// </summary>
    [Description("串口协议")]
    SerialPort = 2,

    /// <summary>
    /// 厂商 SDK。
    /// </summary>
    [Description("厂商SDK")]
    VendorSdk = 3,

    /// <summary>
    /// HTTP 协议。
    /// </summary>
    [Description("HTTP协议")]
    Http = 4,
}
