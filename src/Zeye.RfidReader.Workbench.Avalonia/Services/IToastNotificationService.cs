using Zeye.RfidReader.Workbench.Avalonia.Models;

namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// Toast 通知服务抽象。
/// </summary>
public interface IToastNotificationService
{
    /// <summary>
    /// 通知集合变化事件。
    /// </summary>
    event EventHandler<UiNotificationModel>? NotificationReceived;

    /// <summary>
    /// 显示普通通知。
    /// </summary>
    /// <param name="title">标题。</param>
    /// <param name="message">消息。</param>
    void ShowInfo(string title, string message);

    /// <summary>
    /// 显示错误通知。
    /// </summary>
    /// <param name="title">标题。</param>
    /// <param name="message">消息。</param>
    void ShowError(string title, string message);
}
