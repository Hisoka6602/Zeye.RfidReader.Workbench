using Zeye.RfidReader.Workbench.Application.Options;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Devices;
using Zeye.RfidReader.Workbench.Contracts.Events.Devices;

namespace Zeye.RfidReader.Workbench.Infrastructure.Drivers.Vendors.Simulated;

/// <summary>
/// 模拟 RFID 读码器会话。
/// </summary>
public sealed class SimulatedRfidReaderSession : IRfidReaderSession
{
    private readonly RfidReaderDeviceOptions _options;
    private RfidReaderEventHandler<RfidTagReadEventArgs>? _tagRead;
    private RfidReaderEventHandler<RfidReaderStatusChangedEventArgs>? _statusChanged;
    private RfidReaderEventHandler<RfidReaderFaultedEventArgs>? _faulted;

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
    public event RfidReaderEventHandler<RfidTagReadEventArgs>? TagRead
    {
        add => _tagRead += value;
        remove => _tagRead -= value;
    }

    /// <inheritdoc />
    public event RfidReaderEventHandler<RfidReaderStatusChangedEventArgs>? StatusChanged
    {
        add => _statusChanged += value;
        remove => _statusChanged -= value;
    }

    /// <inheritdoc />
    public event RfidReaderEventHandler<RfidReaderFaultedEventArgs>? Faulted
    {
        add => _faulted += value;
        remove => _faulted -= value;
    }

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
