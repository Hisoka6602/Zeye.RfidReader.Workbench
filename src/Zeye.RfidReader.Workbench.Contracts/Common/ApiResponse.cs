namespace Zeye.RfidReader.Workbench.Contracts.Common;

/// <summary>
/// 通用 API 响应。
/// </summary>
public sealed record class ApiResponse
{
    /// <summary>
    /// 成功状态标记。
    /// </summary>
    public bool IsSuccess { get; init; }

    /// <summary>
    /// 响应消息。
    /// </summary>
    public string? Message { get; init; }
}
