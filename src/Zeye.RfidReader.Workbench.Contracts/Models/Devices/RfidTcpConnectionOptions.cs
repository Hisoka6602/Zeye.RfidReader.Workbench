namespace Zeye.RfidReader.Workbench.Contracts.Models.Devices;

/// <summary>
/// RFID TCP 连接配置。
/// </summary>
public sealed record class RfidTcpConnectionOptions
{
    /// <summary>
    /// 主机地址，可填写范围为本地或局域网可访问地址。
    /// </summary>
    public required string Host { get; init; }

    /// <summary>
    /// 端口号，可填写范围为 1 到 65535。
    /// </summary>
    public required int Port { get; init; }

    /// <summary>
    /// 连接超时时间，单位为毫秒，可填写范围应大于等于 0。
    /// </summary>
    public int ConnectTimeoutMs { get; init; } = 3000;

    /// <summary>
    /// 重连间隔，单位为毫秒，可填写范围应大于等于 0。
    /// </summary>
    public int ReconnectIntervalMs { get; init; } = 3000;
}
