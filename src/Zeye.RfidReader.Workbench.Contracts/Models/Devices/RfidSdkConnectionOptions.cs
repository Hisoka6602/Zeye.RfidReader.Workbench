namespace Zeye.RfidReader.Workbench.Contracts.Models.Devices;

/// <summary>
/// RFID 厂商 SDK 连接配置。
/// </summary>
public sealed record class RfidSdkConnectionOptions
{
    /// <summary>
    /// 服务端点，可填写范围为厂商 SDK 支持的本地或局域网端点。
    /// </summary>
    public string? Endpoint { get; init; }

    /// <summary>
    /// 用户名，可填写范围由厂商 SDK 鉴权规则决定。
    /// </summary>
    public string? Username { get; init; }

    /// <summary>
    /// 密码，可填写范围由厂商 SDK 鉴权规则决定。
    /// </summary>
    public string? Password { get; init; }
}
