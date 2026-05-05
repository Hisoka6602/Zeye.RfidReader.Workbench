using Zeye.RfidReader.Workbench.Domain.Events;

namespace Zeye.RfidReader.Workbench.Domain.Abstractions;

/// <summary>
/// RFID 读码器会话抽象。
/// </summary>
public interface IRfidReaderSession : IAsyncDisposable
{
    /// <summary>
    /// 读码器编码。
    /// </summary>
    string ReaderCode { get; }

    /// <summary>
    /// 连接状态标记。
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// 标签读取事件。
    /// </summary>
    event RfidReaderEventHandler<RfidTagReadEventArgs>? TagRead;

    /// <summary>
    /// 状态变更事件。
    /// </summary>
    event RfidReaderEventHandler<RfidReaderStatusChangedEventArgs>? StatusChanged;

    /// <summary>
    /// 故障事件。
    /// </summary>
    event RfidReaderEventHandler<RfidReaderFaultedEventArgs>? Faulted;

    /// <summary>
    /// 连接读码器。
    /// </summary>
    /// <param name="cancellationToken">取消令牌。</param>
    /// <returns>异步操作。</returns>
    ValueTask ConnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 断开读码器连接。
    /// </summary>
    /// <param name="cancellationToken">取消令牌。</param>
    /// <returns>异步操作。</returns>
    ValueTask DisconnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 开始读码。
    /// </summary>
    /// <param name="cancellationToken">取消令牌。</param>
    /// <returns>异步操作。</returns>
    ValueTask StartReadingAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 停止读码。
    /// </summary>
    /// <param name="cancellationToken">取消令牌。</param>
    /// <returns>异步操作。</returns>
    ValueTask StopReadingAsync(CancellationToken cancellationToken = default);
}
