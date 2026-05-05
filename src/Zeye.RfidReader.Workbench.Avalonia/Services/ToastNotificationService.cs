using Zeye.RfidReader.Workbench.Avalonia.Models;

namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// Toast 通知服务。
/// </summary>
public sealed class ToastNotificationService : IToastNotificationService
{
    /// <inheritdoc />
    public event EventHandler<UiNotificationModel>? NotificationReceived;

    /// <inheritdoc />
    public void ShowInfo(string title, string message)
    {
        Raise(title, message, isError: false);
    }

    /// <inheritdoc />
    public void ShowError(string title, string message)
    {
        Raise(title, message, isError: true);
    }

    /// <summary>
    /// 触发通知。
    /// </summary>
    /// <param name="title">标题。</param>
    /// <param name="message">消息。</param>
    /// <param name="isError">是否为错误。</param>
    private void Raise(string title, string message, bool isError)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        NotificationReceived?.Invoke(this, new UiNotificationModel
        {
            Title = title,
            Message = message,
            IsError = isError,
            OccurredTimeLocal = DateTime.Now
        });
    }
}
