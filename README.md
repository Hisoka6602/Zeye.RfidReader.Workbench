# Zeye.RfidReader.Workbench

## 项目简介

Zeye.RfidReader.Workbench 是 RFID 读码器工作台的架构基线工程。本阶段聚焦契约收敛、CI 门禁、Avalonia 12.0.2 桌面骨架与 Lottie 动画接入，不包含真实厂商 SDK、TCP 读码、串口读码、数据库或外部系统上报实现。

## 当前分层结构

- `Contracts`：跨层共享接口、枚举、事件载荷与通用契约。
- `Application`：应用层入口与 `Options` 配置结构。
- `Infrastructure`：驱动注册、驱动工厂、时钟实现与模拟会话。
- `Avalonia`：桌面 UI、依赖注入组合根与 Lottie 动画展示。
- `Domain`：纯领域对象与预留领域目录。
- `tests`：分层测试项目。
- `.github/workflows`：CI 工作流与架构门禁。

## 文件树

```text
Zeye.RfidReader.Workbench
├── .github
│   ├── copilot-instructions.md
│   └── workflows
│       └── ci.yml
├── docs
│   ├── RFID驱动契约说明.md
│   ├── 厂商接入指南.md
│   └── 架构说明.md
├── src
│   ├── Zeye.RfidReader.Workbench.Application
│   │   ├── DependencyInjection
│   │   │   └── ServiceCollectionExtensions.cs
│   │   ├── Devices
│   │   │   └── .gitkeep
│   │   ├── Options
│   │   │   ├── RfidReadOptions.cs
│   │   │   ├── RfidReaderDeviceOptions.cs
│   │   │   ├── RfidReadersOptions.cs
│   │   │   ├── RfidSdkConnectionOptions.cs
│   │   │   ├── RfidSerialPortConnectionOptions.cs
│   │   │   └── RfidTcpConnectionOptions.cs
│   │   ├── Tags
│   │   │   └── .gitkeep
│   │   ├── Zeye.RfidReader.Workbench.Application.csproj
│   │   └── Abstractions
│   │       └── .gitkeep
│   ├── Zeye.RfidReader.Workbench.Avalonia
│   │   ├── App.axaml
│   │   ├── App.axaml.cs
│   │   ├── Assets
│   │   │   └── Animations
│   │   │       └── rfid-reader-loading.json
│   │   ├── Converters
│   │   │   └── .gitkeep
│   │   ├── DependencyInjection
│   │   │   └── ServiceCollectionExtensions.cs
│   │   ├── Models
│   │   │   └── .gitkeep
│   │   ├── Program.cs
│   │   ├── Services
│   │   │   └── .gitkeep
│   │   ├── ViewModels
│   │   │   └── MainWindowViewModel.cs
│   │   ├── Views
│   │   │   ├── MainWindow.axaml
│   │   │   └── MainWindow.axaml.cs
│   │   └── Zeye.RfidReader.Workbench.Avalonia.csproj
│   ├── Zeye.RfidReader.Workbench.Contracts
│   │   ├── Abstractions
│   │   │   ├── Devices
│   │   │   │   └── IRfidReaderSession.cs
│   │   │   ├── Drivers
│   │   │   │   └── IRfidReaderDriverFactory.cs
│   │   │   └── Time
│   │   │       └── ILocalClock.cs
│   │   ├── Common
│   │   │   └── ApiResponse.cs
│   │   ├── Devices
│   │   │   └── .gitkeep
│   │   ├── Enums
│   │   │   └── Devices
│   │   │       ├── RfidReaderCapability.cs
│   │   │       ├── RfidReaderConnectionState.cs
│   │   │       ├── RfidReaderProtocolType.cs
│   │   │       └── RfidReaderVendorType.cs
│   │   ├── Events
│   │   │   └── Devices
│   │   │       ├── RfidReaderEventHandler.cs
│   │   │       ├── RfidReaderFaultedEventArgs.cs
│   │   │       ├── RfidReaderStatusChangedEventArgs.cs
│   │   │       └── RfidTagReadEventArgs.cs
│   │   ├── Tags
│   │   │   └── RfidTagReadReportRequest.cs
│   │   └── Zeye.RfidReader.Workbench.Contracts.csproj
│   ├── Zeye.RfidReader.Workbench.Domain
│   │   ├── Abstractions
│   │   │   └── .gitkeep
│   │   ├── Devices
│   │   │   └── .gitkeep
│   │   ├── Events
│   │   │   └── .gitkeep
│   │   ├── Tags
│   │   │   └── RfidTag.cs
│   │   ├── ValueObjects
│   │   │   └── .gitkeep
│   │   └── Zeye.RfidReader.Workbench.Domain.csproj
│   └── Zeye.RfidReader.Workbench.Infrastructure
│       ├── DependencyInjection
│       │   └── ServiceCollectionExtensions.cs
│       ├── Drivers
│       │   ├── Abstractions
│       │   │   ├── RfidReaderDriverDescriptor.cs
│       │   │   └── RfidReaderDriverRegistry.cs
│       │   ├── Factory
│       │   │   └── RfidReaderDriverFactory.cs
│       │   └── Vendors
│       │       └── Simulated
│       │           └── SimulatedRfidReaderSession.cs
│       ├── Time
│       │   └── LocalClock.cs
│       └── Zeye.RfidReader.Workbench.Infrastructure.csproj
├── tests
│   ├── Zeye.RfidReader.Workbench.Application.Tests
│   │   ├── RfidReadersOptionsTests.cs
│   │   └── Zeye.RfidReader.Workbench.Application.Tests.csproj
│   ├── Zeye.RfidReader.Workbench.Domain.Tests
│   │   ├── RfidReaderEnumsTests.cs
│   │   └── Zeye.RfidReader.Workbench.Domain.Tests.csproj
│   └── Zeye.RfidReader.Workbench.Infrastructure.Tests
│       ├── RfidReaderDriverRegistryTests.cs
│       └── Zeye.RfidReader.Workbench.Infrastructure.Tests.csproj
├── README.md
└── Zeye.RfidReader.Workbench.sln
```

## 逐文件职责

### .github

- `.github/copilot-instructions.md`：定义仓库级 Copilot 约束与交付门禁。
- `.github/workflows/ci.yml`：执行还原、构建、测试与架构门禁检查。

### docs

- `架构说明.md`：说明分层职责、契约迁移、Lottie 接入与 CI 门禁概览。
- `RFID驱动契约说明.md`：说明会话契约、事件载荷规范与后续客户端抽象建议。
- `厂商接入指南.md`：沉淀厂商驱动扩展边界与 ZakYip.PlcBridge 借鉴原则。

### Application

- `ServiceCollectionExtensions.cs`：预留 Application 层依赖注入入口。
- `RfidReadersOptions.cs`：定义 RFID 读码器配置根节点。
- `RfidReaderDeviceOptions.cs`：定义单台读码器设备配置。
- `RfidTcpConnectionOptions.cs`：定义 TCP 连接配置。
- `RfidSerialPortConnectionOptions.cs`：定义串口连接配置。
- `RfidSdkConnectionOptions.cs`：定义厂商 SDK 连接配置。
- `RfidReadOptions.cs`：定义读码参数配置。

### Avalonia

- `Program.cs`：负责桌面应用启动。
- `App.axaml`：提供 Avalonia 应用 XAML 骨架。
- `App.axaml.cs`：负责组合根服务创建、主窗口解析与容器释放。
- `Assets/Animations/rfid-reader-loading.json`：提供本地 Lottie 动画资源。
- `ViewModels/MainWindowViewModel.cs`：提供主窗口展示文案，不承载设备通信逻辑。
- `Views/MainWindow.axaml`：展示主界面、架构说明与 Lottie 动画占位。
- `Views/MainWindow.axaml.cs`：提供主窗口初始化与 ViewModel 注入。
- `DependencyInjection/ServiceCollectionExtensions.cs`：注册 UI 层窗口与视图模型。

### Contracts

- `ApiResponse.cs`：定义通用响应契约。
- `IRfidReaderSession.cs`：定义读码器会话抽象。
- `IRfidReaderDriverFactory.cs`：定义读码器驱动工厂抽象。
- `ILocalClock.cs`：定义本地时钟抽象。
- `RfidReaderVendorType.cs`：定义读码器厂商枚举。
- `RfidReaderProtocolType.cs`：定义读码器协议枚举。
- `RfidReaderConnectionState.cs`：定义读码器连接状态枚举。
- `RfidReaderCapability.cs`：定义读码器能力标记枚举。
- `RfidTagReadEventArgs.cs`：定义标签读取事件载荷。
- `RfidReaderStatusChangedEventArgs.cs`：定义连接状态变化事件载荷。
- `RfidReaderFaultedEventArgs.cs`：定义故障事件载荷。
- `RfidReaderEventHandler.cs`：定义统一设备事件处理委托。
- `RfidTagReadReportRequest.cs`：定义标签读取上报请求契约。

### Domain

- `RfidTag.cs`：定义 RFID 标签领域对象。

### Infrastructure

- `ServiceCollectionExtensions.cs`：注册 Infrastructure 服务与模拟驱动描述。
- `RfidReaderDriverDescriptor.cs`：定义驱动描述与会话创建委托。
- `RfidReaderDriverRegistry.cs`：维护驱动注册表并提供必需驱动查询。
- `RfidReaderDriverFactory.cs`：根据设备配置创建读码器会话。
- `SimulatedRfidReaderSession.cs`：提供模拟读码器会话骨架，不生成模拟标签。
- `LocalClock.cs`：提供本地系统时间。

### Tests

- `RfidReaderEnumsTests.cs`：验证 Contracts 枚举描述特性。
- `RfidReadersOptionsTests.cs`：验证 Application 配置默认值。
- `RfidReaderDriverRegistryTests.cs`：验证 Infrastructure 驱动注册表行为。

## 分层依赖关系

```text
Domain
    无项目依赖

Contracts
    无业务层项目依赖

Application
    -> Contracts

Infrastructure
    -> Application
    -> Contracts

Avalonia
    -> Application
    -> Infrastructure
    -> Contracts
```

禁止依赖方向：

- `Domain -> Application / Infrastructure / Avalonia / Contracts`
- `Application -> Infrastructure / Avalonia`
- `Contracts -> Application / Infrastructure / Avalonia / Domain`
- `Infrastructure -> Avalonia`
- `Avalonia -> 具体厂商 SDK`

## 多厂商 RFID 驱动接入规则

- 新增厂商驱动时，只能新增 `Infrastructure/Drivers/Vendors/{VendorName}` 下的驱动实现和注册逻辑。
- 不得修改 Contracts 契约来适配单个厂商。
- 不得在 Avalonia 层直接引用厂商 SDK。
- 不得在 Application 层写 `if vendor == xxx` 的厂商分支。
- 新增、删除、移动文件后必须同步更新 README.md 文件树与逐文件职责。

## 当前已实现能力

- 建立 Domain、Application、Infrastructure、Contracts、Avalonia 分层项目。
- 将共享枚举、接口与事件载荷统一迁移到 `Contracts`。
- 修正 Avalonia 启动流程，移除 `Program.cs` 中的全局静态容器暴露。
- 新增适用于 Avalonia `12.0.2` 的 Lottie 动画占位。
- 新增 GitHub Actions CI 工作流与架构门禁检查。
- 保持当前阶段不实现真实 RFID 业务通信。

## 本次更新内容

- 新增 `.github/workflows/ci.yml`，执行还原、构建、测试与架构门禁检查。
- 将枚举、接口、事件载荷迁移到 `Contracts` 规定目录并更新引用。
- 将设备事件载荷统一改为 `readonly record struct`。
- 为 Avalonia 主界面接入 `Avalonia.Labs.Lottie 12.0.2` 与本地动画资源。
- 将 docs 重命名为中文文件名并补充架构与借鉴说明。

## 后续可完善点

- 增加真实厂商 SDK 驱动适配。
- 引入 Application 层设备编排服务与 UI 状态分发抽象。
- 增加真实设备状态展示模型与读码统计页面。
- 在接入 NLog 后补充 `archiveAboveSize="10485760"` 的实际配置与验证。

## Copilot 开发门禁

- 所有 public 类型、public 成员、public 方法必须有中文 XML 注释。
- 注释中禁止出现第二人称字眼。
- 类名、字段名、变量名禁止中文。
- DTO、Options、Contract 优先使用 `record class`。
- 事件载荷必须使用 `readonly record struct`。
- 布尔属性必须使用 `Is` / `Has` / `Can` / `Should` 前缀。
- enum 必须带 `Description` 特性，每个枚举项必须有 XML 注释。
- 时间统一使用本地时间语义，属性命名必须带 `Local`。
- 异常提示使用中文。
- 不得把业务逻辑放入 Avalonia ViewModel。
- 不得把设备通信实现放入 Application。
