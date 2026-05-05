namespace Zeye.RfidReader.Workbench.Contracts.Abstractions.Time;

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
