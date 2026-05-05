namespace Zeye.RfidReader.Workbench.Application.Options;

/// <summary>
/// RFID 厂商 SDK 连接配置。
/// </summary>
public sealed record class RfidSdkConnectionOptions
{
    /// <summary>
    /// 服务端点。
    /// </summary>
    public string? Endpoint { get; init; }

    /// <summary>
    /// 用户名。
    /// </summary>
    public string? Username { get; init; }

    /// <summary>
    /// 密码。
    /// </summary>
    public string? Password { get; init; }
}
