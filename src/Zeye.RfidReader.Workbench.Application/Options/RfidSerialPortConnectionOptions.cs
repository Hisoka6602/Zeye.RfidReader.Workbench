namespace Zeye.RfidReader.Workbench.Application.Options;

/// <summary>
/// RFID 串口连接配置。
/// </summary>
public sealed record class RfidSerialPortConnectionOptions
{
    /// <summary>
    /// 串口名称。
    /// </summary>
    public required string PortName { get; init; }

    /// <summary>
    /// 波特率。
    /// </summary>
    public int BaudRate { get; init; } = 115200;
}
