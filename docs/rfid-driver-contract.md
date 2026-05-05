# RFID 驱动契约

## IRfidReaderSession

`IRfidReaderSession` 是 Domain 层的读码器会话抽象，表示一台 RFID 读码器的连接与读码生命周期。核心职责包括：

- 暴露 `ReaderCode` 标识读码器。
- 暴露 `IsConnected` 表示连接状态。
- 通过 `TagRead` 发布标签读取事件。
- 通过 `StatusChanged` 发布连接状态变更事件。
- 通过 `Faulted` 发布故障事件。
- 提供 `ConnectAsync`、`DisconnectAsync`、`StartReadingAsync`、`StopReadingAsync` 生命周期方法。
- 通过 `IAsyncDisposable` 释放设备或 SDK 资源。

## IRfidReaderDriverFactory

`IRfidReaderDriverFactory` 是 Application 层的驱动工厂抽象。应用编排逻辑只通过该接口根据 `RfidReaderDeviceOptions` 创建 `IRfidReaderSession`，不需要了解厂商实现类型。

## RfidReaderDriverRegistry

`RfidReaderDriverRegistry` 是 Infrastructure 层的驱动注册表。注册表使用 `(VendorType, ProtocolType)` 作为键，保存 `RfidReaderDriverDescriptor`。重复注册会抛出中文异常，未找到驱动也会抛出中文异常。

## RfidReaderDriverDescriptor

`RfidReaderDriverDescriptor` 描述单个驱动实现，包含：

- `VendorType`：厂商类型。
- `ProtocolType`：协议类型。
- `DisplayName`：显示名称。
- `CreateSession`：会话创建委托。

## 新增厂商驱动最小文件清单

新增厂商时，最小文件清单如下：

```text
src/Zeye.RfidReader.Workbench.Infrastructure/Drivers/Vendors/{VendorName}/{VendorName}RfidReaderSession.cs
src/Zeye.RfidReader.Workbench.Infrastructure/DependencyInjection/ServiceCollectionExtensions.cs
```

如果厂商需要专用配置且现有 Options 无法表达，应优先评估是否可放入 `RfidSdkConnectionOptions`。只有确认为通用能力时，才调整 Application Options 或 Domain 枚举。

## 当前模拟驱动

当前只注册模拟驱动：

```text
VendorType = Simulated
ProtocolType = VendorSdk
DisplayName = 模拟RFID读码器
```

模拟驱动只维护连接状态，不生成标签，不启动后台循环。
