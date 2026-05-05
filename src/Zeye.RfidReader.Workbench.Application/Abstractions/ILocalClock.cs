namespace Zeye.RfidReader.Workbench.Application.Abstractions;

/// <summary>
/// 本地时钟抽象。
/// </summary>
public interface ILocalClock
{
    /// <summary>
    /// 当前本地时间。
    /// </summary>
    DateTime Now { get; }
}
