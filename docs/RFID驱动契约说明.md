# RFID 驱动契约说明

## 会话抽象

`IRfidReaderSession` 现定义在 `Contracts/Abstractions/Devices`，用于表达读码器会话的最小能力：

- 读取 `ReaderCode` 与 `IsConnected`。
- 调用 `ConnectAsync`、`DisconnectAsync`、`StartReadingAsync`、`StopReadingAsync`。
- 通过事件向上游发布读码、状态变化与故障通知。

## 事件载荷规范

所有设备事件载荷均位于 `Contracts/Events/Devices`，并统一使用 `readonly record struct`：

- `RfidTagReadEventArgs`
- `RfidReaderStatusChangedEventArgs`
- `RfidReaderFaultedEventArgs`

约束说明：

- 时间字段统一使用本地时间命名：`ReadTimeLocal`、`ChangedTimeLocal`、`FaultedTimeLocal`。
- 事件载荷保持不可变值语义，便于跨层传递与降低额外分配。
- 事件处理委托 `RfidReaderEventHandler<TArgs>` 也已放入 `Contracts`，避免跨层依赖回流。

## 后续客户端抽象建议

参考 `Hisoka6602/ZakYip.PlcBridge` 的客户端经验，后续可继续在 `Contracts/Abstractions/Devices` 中补充：

- `IRfidReaderClient`：聚焦单个设备连接生命周期。
- `IRfidReaderClientManager`：聚焦多设备管理、重连编排与状态广播。

本次仅沉淀原则，不直接落地真实设备客户端实现，避免在尚未引入应用编排层之前把设备通信逻辑压入 UI。
