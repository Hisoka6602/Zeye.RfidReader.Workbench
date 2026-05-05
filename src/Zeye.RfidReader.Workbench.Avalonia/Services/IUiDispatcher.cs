namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// UI 调度器抽象。
/// </summary>
public interface IUiDispatcher
{
    /// <summary>
    /// 在 UI 线程执行异步操作。
    /// </summary>
    /// <param name="action">异步操作。</param>
    /// <returns>异步任务。</returns>
    Task InvokeAsync(Func<Task> action);

    /// <summary>
    /// 在 UI 线程投递同步操作。
    /// </summary>
    /// <param name="action">同步操作。</param>
    void Post(Action action);
}
