using Xunit;
using Zeye.RfidReader.Workbench.Avalonia.Models;
using Zeye.RfidReader.Workbench.Avalonia.Services;

namespace Zeye.RfidReader.Workbench.Avalonia.Tests;

/// <summary>
/// Toast 通知服务测试。
/// </summary>
public sealed class ToastNotificationServiceTests
{
    /// <summary>
    /// 通知事件应被触发。
    /// </summary>
    [Fact]
    public void ShowInfo_ShouldRaiseNotificationReceived()
    {
        var service = new ToastNotificationService();
        var startTime = DateTime.Now;
        UiNotificationModel? notification = null;

        service.NotificationReceived += OnNotificationReceived;

        service.ShowInfo("提示", "UI 底座已准备完成");

        Assert.NotNull(notification);
        Assert.Equal("提示", notification!.Title);
        Assert.Equal("UI 底座已准备完成", notification.Message);
        Assert.False(notification.IsError);
        Assert.InRange(notification.OccurredTimeLocal, startTime, DateTime.Now);
        service.NotificationReceived -= OnNotificationReceived;
        return;

        /// <summary>
        /// 捕获通知模型。
        /// </summary>
        /// <param name="sender">事件发送方。</param>
        /// <param name="model">通知模型。</param>
        void OnNotificationReceived(object? sender, UiNotificationModel model)
        {
            notification = model;
        }
    }
}
