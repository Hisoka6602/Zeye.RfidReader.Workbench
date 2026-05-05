namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// 对话框服务抽象。
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// 显示消息。
    /// </summary>
    /// <param name="title">标题。</param>
    /// <param name="message">消息。</param>
    /// <returns>异步任务。</returns>
    Task ShowMessageAsync(string title, string message);
}
