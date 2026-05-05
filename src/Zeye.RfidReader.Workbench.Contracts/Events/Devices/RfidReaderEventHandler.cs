namespace Zeye.RfidReader.Workbench.Contracts.Events.Devices;

/// <summary>
/// RFID 读码器事件处理委托。
/// </summary>
/// <typeparam name="TArgs">事件载荷类型。</typeparam>
/// <param name="sender">事件发送方。</param>
/// <param name="eventArgs">事件载荷。</param>
public delegate void RfidReaderEventHandler<TArgs>(object? sender, TArgs eventArgs);
