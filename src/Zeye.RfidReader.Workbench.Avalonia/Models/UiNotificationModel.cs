namespace Zeye.RfidReader.Workbench.Avalonia.Models;

/// <summary>
/// UI 通知显示模型。
/// </summary>
public sealed record class UiNotificationModel
{
    /// <summary>
    /// 通知标题。
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// 通知内容。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// 是否为错误通知。
    /// </summary>
    public bool IsError { get; init; }

    /// <summary>
    /// 本地发生时间。
    /// </summary>
    public required DateTime OccurredTimeLocal { get; init; }
}
