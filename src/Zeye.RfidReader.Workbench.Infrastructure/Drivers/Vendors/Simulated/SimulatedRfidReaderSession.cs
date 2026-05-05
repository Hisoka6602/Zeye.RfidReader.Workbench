using Zeye.RfidReader.Workbench.Application.Options;
using Zeye.RfidReader.Workbench.Domain.Abstractions;
using Zeye.RfidReader.Workbench.Domain.Events;

namespace Zeye.RfidReader.Workbench.Infrastructure.Drivers.Vendors.Simulated;

/// <summary>
/// 模拟 RFID 读码器会话。
/// </summary>
public sealed class SimulatedRfidReaderSession : IRfidReaderSession
{
    private readonly RfidReaderDeviceOptions _options;

    /// <summary>
    /// 初始化模拟 RFID 读码器会话实例。
    /// </summary>
    /// <param name="options">读码器设备配置。</param>
    public SimulatedRfidReaderSession(RfidReaderDeviceOptions options)
    {
        _options = options;
    }

    /// <inheritdoc />
    public string ReaderCode => _options.ReaderCode;

    /// <inheritdoc />
    public bool IsConnected { get; private set; }

    /// <inheritdoc />
    public event EventHandler<RfidTagReadEventArgs>? TagRead;

    /// <inheritdoc />
    public event EventHandler<RfidReaderStatusChangedEventArgs>? StatusChanged;

    /// <inheritdoc />
    public event EventHandler<RfidReaderFaultedEventArgs>? Faulted;

    /// <inheritdoc />
    public ValueTask ConnectAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IsConnected = true;
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc />
    public ValueTask DisconnectAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IsConnected = false;
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc />
    public ValueTask StartReadingAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc />
    public ValueTask StopReadingAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc />
    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
