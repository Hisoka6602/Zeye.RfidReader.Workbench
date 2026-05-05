namespace Zeye.RfidReader.Workbench.Contracts.Models.Devices;

/// <summary>
/// RFID 串口连接配置。
/// </summary>
public sealed record class RfidSerialPortConnectionOptions
{
    /// <summary>
    /// 串口名称，可填写范围为当前操作系统可识别的串口标识。
    /// </summary>
    public required string PortName { get; init; }

    /// <summary>
    /// 波特率，可填写范围需与设备串口参数一致且大于 0。
    /// </summary>
    public int BaudRate { get; init; } = 115200;
}
