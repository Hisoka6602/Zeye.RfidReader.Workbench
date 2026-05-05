# Zeye.RfidReader.Workbench

## 项目简介

Zeye.RfidReader.Workbench 是 RFID 读码器工作台的架构基线工程。本阶段只建立工程分层、抽象契约、配置模型、驱动注册机制与模拟驱动骨架，不包含真实厂商 SDK、TCP 读码、串口读码、数据库或外部系统上报实现。

## 当前分层结构

- `Domain`：领域模型、领域枚举、领域事件载荷与读码器会话抽象，不依赖外部框架。
- `Contracts`：跨进程或外部接口使用的数据契约，不依赖业务层项目。
- `Application`：应用抽象、配置 Options、本地时钟抽象与驱动工厂抽象。
- `Infrastructure`：驱动注册表、驱动工厂实现、本地时钟实现与模拟驱动骨架。
- `Avalonia`：桌面 UI 工程骨架，只保留入口、主窗口、视图模型与目录占位。
- `tests`：分层测试项目骨架。

## 文件树

```text
Zeye.RfidReader.Workbench
├── src
│   ├── Zeye.RfidReader.Workbench.Domain
│   │   ├── Abstractions
│   │   │   └── IRfidReaderSession.cs
│   │   ├── Devices
│   │   │   ├── RfidReaderCapability.cs
│   │   │   ├── RfidReaderConnectionState.cs
│   │   │   ├── RfidReaderProtocolType.cs
│   │   │   └── RfidReaderVendorType.cs
│   │   ├── Events
│   │   │   ├── RfidReaderFaultedEventArgs.cs
│   │   │   ├── RfidReaderEventHandler.cs
│   │   │   ├── RfidReaderStatusChangedEventArgs.cs
│   │   │   └── RfidTagReadEventArgs.cs
│   │   ├── Tags
│   │   │   └── RfidTag.cs
│   │   ├── ValueObjects
│   │   │   └── .gitkeep
│   │   └── Zeye.RfidReader.Workbench.Domain.csproj
│   ├── Zeye.RfidReader.Workbench.Application
│   │   ├── Abstractions
│   │   │   ├── ILocalClock.cs
│   │   │   └── IRfidReaderDriverFactory.cs
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
│   │   └── Zeye.RfidReader.Workbench.Application.csproj
│   ├── Zeye.RfidReader.Workbench.Infrastructure
│   │   ├── DependencyInjection
│   │   │   └── ServiceCollectionExtensions.cs
│   │   ├── Drivers
│   │   │   ├── Abstractions
│   │   │   │   ├── RfidReaderDriverDescriptor.cs
│   │   │   │   └── RfidReaderDriverRegistry.cs
│   │   │   ├── Factory
│   │   │   │   └── RfidReaderDriverFactory.cs
│   │   │   └── Vendors
│   │   │       └── Simulated
│   │   │           └── SimulatedRfidReaderSession.cs
│   │   ├── Time
│   │   │   └── LocalClock.cs
│   │   └── Zeye.RfidReader.Workbench.Infrastructure.csproj
│   ├── Zeye.RfidReader.Workbench.Contracts
│   │   ├── Common
│   │   │   └── ApiResponse.cs
│   │   ├── Devices
│   │   │   └── .gitkeep
│   │   ├── Tags
│   │   │   └── RfidTagReadReportRequest.cs
│   │   └── Zeye.RfidReader.Workbench.Contracts.csproj
│   └── Zeye.RfidReader.Workbench.Avalonia
│       ├── App.axaml
│       ├── App.axaml.cs
│       ├── Converters
│       │   └── .gitkeep
│       ├── DependencyInjection
│       │   └── ServiceCollectionExtensions.cs
│       ├── Models
│       │   └── .gitkeep
│       ├── Program.cs
│       ├── Services
│       │   └── .gitkeep
│       ├── ViewModels
│       │   └── MainWindowViewModel.cs
│       ├── Views
│       │   ├── MainWindow.axaml
│       │   └── MainWindow.axaml.cs
│       └── Zeye.RfidReader.Workbench.Avalonia.csproj
├── tests
│   ├── Zeye.RfidReader.Workbench.Domain.Tests
│   │   ├── RfidReaderEnumsTests.cs
│   │   └── Zeye.RfidReader.Workbench.Domain.Tests.csproj
│   ├── Zeye.RfidReader.Workbench.Application.Tests
│   │   ├── RfidReadersOptionsTests.cs
│   │   └── Zeye.RfidReader.Workbench.Application.Tests.csproj
│   └── Zeye.RfidReader.Workbench.Infrastructure.Tests
│       ├── RfidReaderDriverRegistryTests.cs
│       └── Zeye.RfidReader.Workbench.Infrastructure.Tests.csproj
├── docs
│   ├── architecture.md
│   ├── rfid-driver-contract.md
│   └── vendor-integration-guide.md
├── README.md
└── Zeye.RfidReader.Workbench.sln
```

## 逐文件职责

### Domain

- `IRfidReaderSession.cs`：定义读码器连接、断开、开始读码、停止读码与事件订阅抽象。
- `RfidReaderVendorType.cs`：定义厂商枚举，作为多厂商扩展入口。
- `RfidReaderProtocolType.cs`：定义 TCP、串口、厂商 SDK、HTTP 等协议类型。
- `RfidReaderConnectionState.cs`：定义读码器连接状态。
- `RfidReaderCapability.cs`：定义读码器能力标记。
- `RfidTag.cs`：定义 RFID 标签领域对象。
- `RfidTagReadEventArgs.cs`：定义标签读取事件载荷。
- `RfidReaderEventHandler.cs`：定义 RFID 读码器事件处理委托。
- `RfidReaderStatusChangedEventArgs.cs`：定义连接状态变化事件载荷。
- `RfidReaderFaultedEventArgs.cs`：定义读码器故障事件载荷。

### Application

- `RfidReadersOptions.cs`：定义 RFID 读码器配置根节点。
- `RfidReaderDeviceOptions.cs`：定义单台读码器设备配置。
- `RfidTcpConnectionOptions.cs`：定义 TCP 连接配置。
- `RfidSerialPortConnectionOptions.cs`：定义串口连接配置。
- `RfidSdkConnectionOptions.cs`：定义厂商 SDK 连接配置。
- `RfidReadOptions.cs`：定义读码参数配置。
- `IRfidReaderDriverFactory.cs`：定义读码器驱动工厂抽象。
- `ILocalClock.cs`：定义本地时钟抽象。
- `ServiceCollectionExtensions.cs`：预留 Application 层依赖注入入口。

### Infrastructure

- `RfidReaderDriverDescriptor.cs`：定义驱动描述与会话创建委托。
- `RfidReaderDriverRegistry.cs`：维护驱动注册表并提供必需驱动查询。
- `RfidReaderDriverFactory.cs`：根据设备配置创建读码器会话。
- `SimulatedRfidReaderSession.cs`：提供模拟读码器会话骨架，不生成模拟标签。
- `LocalClock.cs`：提供本地系统时间。
- `ServiceCollectionExtensions.cs`：注册 Infrastructure 服务与模拟驱动描述。

### Contracts

- `ApiResponse.cs`：定义通用响应契约。
- `RfidTagReadReportRequest.cs`：定义标签读取上报请求契约。

### Avalonia

- `Program.cs`：提供桌面工程入口与依赖注入容器初始化。
- `App.axaml`：提供 Avalonia 应用 XAML 骨架。
- `App.axaml.cs`：提供应用初始化与主窗口依赖解析入口。
- `Views/MainWindow.axaml`：提供主窗口 XAML 骨架与 ViewModel 标题绑定。
- `Views/MainWindow.axaml.cs`：提供主窗口初始化，不直接实例化 ViewModel。
- `ViewModels/MainWindowViewModel.cs`：提供主窗口视图模型占位，不包含 RFID 通信逻辑。
- `DependencyInjection/ServiceCollectionExtensions.cs`：注册 UI 层窗口与视图模型。
- `Services/.gitkeep`、`Models/.gitkeep`、`Converters/.gitkeep`：保留 UI 层目录结构。

### Tests

- `RfidReaderEnumsTests.cs`：验证 Domain 枚举描述特性。
- `RfidReadersOptionsTests.cs`：验证 Application 配置默认值。
- `RfidReaderDriverRegistryTests.cs`：验证 Infrastructure 驱动注册表行为。
- `Zeye.RfidReader.Workbench.Domain.Tests.csproj`：Domain 层测试项目。
- `Zeye.RfidReader.Workbench.Application.Tests.csproj`：Application 层测试项目。
- `Zeye.RfidReader.Workbench.Infrastructure.Tests.csproj`：Infrastructure 层测试项目。

## 分层依赖关系

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

禁止依赖方向：

- `Domain -> Application / Infrastructure / Avalonia`
- `Application -> Infrastructure / Avalonia`
- `Contracts -> Application / Infrastructure / Avalonia`
- `Infrastructure -> Avalonia`
- `Avalonia -> 具体厂商 SDK`

## 多厂商 RFID 驱动接入规则

新增厂商驱动时，只能新增 Infrastructure/Drivers/Vendors/{VendorName} 下的驱动实现和注册逻辑。
不得修改 Domain 领域模型来适配某个厂商。
不得在 Avalonia 层直接引用厂商 SDK。
不得在 Application 层写 if vendor == xxx 的厂商分支。
不得保留默认 Class1.cs。
新增、删除、移动文件后必须同步更新 README.md 文件树与逐文件职责。

## 当前已实现能力

- 建立 Domain、Application、Infrastructure、Contracts、Avalonia 分层项目。
- 将 Contracts 项目移动到 `src` 目录。
- 删除默认 `Class1.cs`。
- 定义 RFID 读码器基础枚举、事件载荷、标签对象与会话抽象。
- 定义 Options、驱动工厂抽象、本地时钟抽象。
- 定义驱动注册表、驱动工厂实现、本地时钟实现与模拟驱动骨架。
- 创建 Avalonia 工程骨架目录与主窗口占位。
- 创建测试项目骨架。
- 增加分层最小单元测试。

## 后续待实现能力

- 增加真实厂商 SDK 驱动适配。
- 增加 TCP 与串口读码驱动实现。
- 增加配置加载、设备生命周期管理与读码编排服务。
- 增加标签去重、读码统计与异常恢复策略。
- 增加最小 UI 页面、设备状态展示与配置入口。
- 增加数据库持久化与 WCS/ERP/MES 上报适配。

## 本次更新内容

- 初始化标准 `src` 与 `tests` 工程结构。
- 新增 Domain、Application、Infrastructure、Avalonia、Contracts 基础文件。
- 新增 README 与 docs 架构说明。
- 注册模拟 RFID 读码器驱动描述。
- 保证当前阶段不实现真实 RFID 业务通信。

## Copilot 开发门禁

- 所有 public 类型、public 成员、public 方法必须有中文 XML 注释。
- 注释中禁止出现第二人称字眼。
- 类名、字段名、变量名禁止中文。
- DTO、Options、Contract 优先使用 `record class`。
- 事件载荷必须使用 `record struct` 或 `record class`，名称以 `EventArgs` 结尾。
- 布尔属性必须使用 `Is` / `Has` / `Can` / `Should` 前缀。
- enum 必须带 `Description` 特性，每个枚举项必须有 XML 注释。
- 时间统一使用本地时间语义，属性命名必须带 `Local`。
- 异常提示使用中文。
- 不得把业务逻辑放入 Avalonia ViewModel。
- 不得把设备通信实现放入 Application。
- Domain 禁止依赖外部框架。
- 新增、删除、移动文件后必须同步更新 README.md 文件树与逐文件职责。
