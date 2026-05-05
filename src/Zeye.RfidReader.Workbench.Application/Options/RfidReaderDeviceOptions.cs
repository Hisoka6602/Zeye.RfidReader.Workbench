using Zeye.RfidReader.Workbench.Domain.Devices;

namespace Zeye.RfidReader.Workbench.Application.Options;

/// <summary>
/// RFID 读码器设备配置。
/// </summary>
public sealed record class RfidReaderDeviceOptions
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    public required string ReaderCode { get; init; }

    /// <summary>
    /// 读码器名称。
    /// </summary>
    public required string ReaderName { get; init; }

    /// <summary>
    /// 厂商类型。
    /// </summary>
    public required RfidReaderVendorType VendorType { get; init; }

    /// <summary>
    /// 协议类型。
    /// </summary>
    public required RfidReaderProtocolType ProtocolType { get; init; }

    /// <summary>
    /// 启用状态标记。
    /// </summary>
    public bool IsEnabled { get; init; }

    /// <summary>
    /// TCP 连接配置。
    /// </summary>
    public RfidTcpConnectionOptions? Tcp { get; init; }

    /// <summary>
    /// 串口连接配置。
    /// </summary>
    public RfidSerialPortConnectionOptions? SerialPort { get; init; }

    /// <summary>
    /// 厂商 SDK 连接配置。
    /// </summary>
    public RfidSdkConnectionOptions? Sdk { get; init; }

    /// <summary>
    /// 读码配置。
    /// </summary>
    public RfidReadOptions Read { get; init; } = new();
}
