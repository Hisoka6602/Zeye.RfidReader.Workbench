# 架构说明

## 项目定位

Zeye.RfidReader.Workbench 是 RFID 读码器工作台工程。本阶段目标是建立架构基线，为后续接入多厂商 RFID 设备、配置加载、读码编排、UI 展示与外部系统集成预留稳定边界。

当前版本不实现真实厂商 SDK、TCP 读码、串口读码、数据库、WCS/ERP/MES 上报或复杂 Avalonia 页面。

## DDD 分层

### Domain

Domain 层保存领域核心概念，包括读码器厂商、协议、连接状态、能力、标签对象、事件载荷与 `IRfidReaderSession` 会话抽象。Domain 不依赖外部框架，不包含厂商 SDK 代码。

### Contracts

Contracts 层保存跨边界数据契约，例如通用响应、标签读取上报请求。Contracts 不依赖业务层项目，避免外部契约反向绑定内部实现。

### Application

Application 层保存应用服务需要的抽象与 Options，包括驱动工厂抽象、本地时钟抽象和读码器配置模型。Application 只依赖 Domain 与 Contracts，不包含设备通信实现。

### Infrastructure

Infrastructure 层保存技术实现，包括驱动注册表、驱动工厂实现、本地时钟实现、模拟读码器会话以及未来的厂商 SDK 适配。设备通信实现统一放在 Infrastructure。

### Avalonia

Avalonia 层保存桌面 UI 工程骨架、视图、视图模型、UI 服务、转换器与依赖注入入口。Avalonia 不直接引用厂商 SDK，不承担 RFID 通信实现。

## 依赖方向

```text
Domain
    无项目依赖

Contracts
    无业务层项目依赖

Application
    -> Domain
    -> Contracts

Infrastructure
    -> Application
    -> Domain
    -> Contracts

Avalonia
    -> Application
    -> Infrastructure
    -> Contracts
```

## 各层职责

- Domain：定义稳定领域概念和设备会话抽象。
- Contracts：定义跨进程或外部接口使用的数据结构。
- Application：定义业务编排所需抽象与配置对象。
- Infrastructure：实现设备驱动、注册机制、本地时钟等技术能力。
- Avalonia：展示 UI 与用户交互，不实现设备通信。

## 禁止事项

- 禁止 `Domain` 依赖 `Application`、`Infrastructure` 或 `Avalonia`。
- 禁止 `Application` 依赖 `Infrastructure` 或 `Avalonia`。
- 禁止 `Contracts` 依赖业务层项目。
- 禁止 `Infrastructure` 依赖 `Avalonia`。
- 禁止在 Avalonia 层直接引用厂商 SDK。
- 禁止在 Application 层编写厂商分支逻辑。
- 禁止为适配某个厂商修改通用领域模型。

## 多厂商驱动放在 Infrastructure 的原因

厂商 SDK、网络协议、串口协议、设备资源释放和异常处理都属于技术实现细节。将这些实现放在 Infrastructure 可以保持 Domain 与 Application 稳定，避免厂商差异污染领域模型和应用编排逻辑。新增厂商时只需要在 `Infrastructure/Drivers/Vendors/{VendorName}` 下新增实现，并通过 `RfidReaderDriverDescriptor` 注册。
