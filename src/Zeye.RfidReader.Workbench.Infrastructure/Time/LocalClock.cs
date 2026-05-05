using Zeye.RfidReader.Workbench.Contracts.Abstractions.Time;

namespace Zeye.RfidReader.Workbench.Infrastructure.Time;

/// <summary>
/// 本地系统时钟。
/// </summary>
public sealed class LocalClock : ILocalClock
{
    /// <inheritdoc />
    public DateTime Now => DateTime.Now;
}
