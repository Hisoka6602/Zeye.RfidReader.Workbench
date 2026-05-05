using Zeye.RfidReader.Workbench.Application.Abstractions;

namespace Zeye.RfidReader.Workbench.Infrastructure.Time;

/// <summary>
/// 本地系统时钟。
/// </summary>
public sealed class LocalClock : ILocalClock
{
    /// <inheritdoc />
    public DateTime Now => DateTime.Now;
}
