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

## 与 Avalonia MVVM 的边界约束

为补齐 Avalonia 端 MVVM 基线，当前已明确以下边界：

- `MainWindowViewModel` 仅使用 `CommunityToolkit.Mvvm 8.4.2` 提供属性通知与命令，不直接引用 `Infrastructure` 具体实现。
- 启动/停止命令当前只更新 UI 状态文本与运行标记，不创建 RFID 会话、不访问 TCP、串口、厂商 SDK、数据库。
- Avalonia 层的 `BuildServiceProvider` 已迁移到独立工厂，避免 ViewModel 或视图代码自行解析容器。

后续若接入真实驱动，应继续通过 `Application` 编排层消费本契约，再向 UI 投递纯展示状态，保持契约层稳定性与分层边界。
