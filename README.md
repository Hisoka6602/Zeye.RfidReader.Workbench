# Zeye.RfidReader.Workbench

## 项目简介

Zeye.RfidReader.Workbench 是面向 RFID 读码器场景的桌面工作台基线工程。当前阶段重点建设 Avalonia UI 底座、分层契约、CI 门禁与测试基线，不包含真实厂商 SDK、TCP/串口读码、数据库或外部系统上报实现。

## 当前分层结构

- `Contracts`：跨层共享接口、枚举、事件载荷、设备模型与通用工具契约。
- `Application`：应用层入口与配置根模型，不承载真实设备通信。
- `Infrastructure`：驱动注册、驱动工厂、模拟会话与本地时钟实现。
- `Avalonia`：桌面 UI、MVVM 视图模型、Shell、导航/对话框/通知/UI 线程服务与动画控件封装。
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
│   │   ├── Abstractions
│   │   │   └── .gitkeep
│   │   ├── DependencyInjection
│   │   │   └── ServiceCollectionExtensions.cs
│   │   ├── Devices
│   │   │   └── .gitkeep
│   │   ├── Options
│   │   │   ├── .gitkeep
│   │   │   └── RfidReadersOptions.cs
│   │   ├── Tags
│   │   │   └── .gitkeep
│   │   └── Zeye.RfidReader.Workbench.Application.csproj
│   ├── Zeye.RfidReader.Workbench.Avalonia
│   │   ├── App.axaml
│   │   ├── App.axaml.cs
│   │   ├── Program.cs
│   │   ├── Assets
│   │   │   └── Animations
│   │   │       └── rfid-reader-loading.json
│   │   ├── Bootstrap
│   │   │   └── AvaloniaServiceProviderFactory.cs
│   │   ├── Controls
│   │   │   ├── RfidLottieView.axaml
│   │   │   └── RfidLottieView.axaml.cs
│   │   ├── DependencyInjection
│   │   │   └── ServiceCollectionExtensions.cs
│   │   ├── Models
│   │   │   ├── NavigationItemModel.cs
│   │   │   ├── ReaderStatusCardModel.cs
│   │   │   └── UiNotificationModel.cs
│   │   ├── Services
│   │   │   ├── AppNavigationService.cs
│   │   │   ├── AvaloniaUiDispatcher.cs
│   │   │   ├── DialogService.cs
│   │   │   ├── IAppNavigationService.cs
│   │   │   ├── IDialogService.cs
│   │   │   ├── IToastNotificationService.cs
│   │   │   ├── IUiDispatcher.cs
│   │   │   ├── PageKeys.cs
│   │   │   └── ToastNotificationService.cs
│   │   ├── ViewModels
│   │   │   ├── DashboardViewModel.cs
│   │   │   ├── LogsViewModel.cs
│   │   │   ├── MainWindowViewModel.cs
│   │   │   ├── ReaderMonitorViewModel.cs
│   │   │   ├── SettingsViewModel.cs
│   │   │   └── ViewModelBase.cs
│   │   ├── Views
│   │   │   ├── DashboardView.axaml
│   │   │   ├── DashboardView.axaml.cs
│   │   │   ├── LogsView.axaml
│   │   │   ├── LogsView.axaml.cs
│   │   │   ├── MainWindow.axaml
│   │   │   ├── MainWindow.axaml.cs
│   │   │   ├── ReaderMonitorView.axaml
│   │   │   ├── ReaderMonitorView.axaml.cs
│   │   │   ├── SettingsView.axaml
│   │   │   └── SettingsView.axaml.cs
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
│   │   ├── Models
│   │   │   └── Devices
│   │   │       ├── RfidReadOptions.cs
│   │   │       ├── RfidReaderDeviceOptions.cs
│   │   │       ├── RfidSdkConnectionOptions.cs
│   │   │       ├── RfidSerialPortConnectionOptions.cs
│   │   │       └── RfidTcpConnectionOptions.cs
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
│   ├── Zeye.RfidReader.Workbench.Avalonia.Tests
│   │   ├── AppNavigationServiceTests.cs
│   │   ├── MainWindowViewModelTests.cs
│   │   ├── TestServiceProviderFactory.cs
│   │   ├── ToastNotificationServiceTests.cs
│   │   └── Zeye.RfidReader.Workbench.Avalonia.Tests.csproj
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
- `.github/workflows/ci.yml`：执行还原、构建、测试与 UI/架构门禁检查。

### docs

- `架构说明.md`：说明当前分层、UI 底座、导航/通知/线程服务与 CI 门禁。
- `RFID驱动契约说明.md`：说明会话契约、事件载荷规范与后续客户端抽象建议。
- `厂商接入指南.md`：沉淀厂商驱动扩展边界与接入原则。

### Application

- `DependencyInjection/ServiceCollectionExtensions.cs`：预留 Application 层依赖注入入口。
- `Options/RfidReadersOptions.cs`：定义 RFID 读码器配置根节点。

### Avalonia

- `Program.cs`：负责桌面应用启动。
- `App.axaml`：注册 Fluent 主题与 ViewModel 到 View 的数据模板映射。
- `App.axaml.cs`：负责通过工厂创建主窗口并在退出时释放容器。
- `Assets/Animations/rfid-reader-loading.json`：提供本地 Lottie 动画资源。
- `Bootstrap/AvaloniaServiceProviderFactory.cs`：集中创建 Avalonia 组合根服务提供器。
- `Controls/RfidLottieView.axaml`：封装可复用的 RFID Lottie 动画展示控件。
- `Controls/RfidLottieView.axaml.cs`：通过 `StyledProperty` 暴露动画路径输入。
- `DependencyInjection/ServiceCollectionExtensions.cs`：注册 UI 服务、页面视图模型、页面视图与主窗口。
- `Models/NavigationItemModel.cs`：定义导航菜单显示模型。
- `Models/ReaderStatusCardModel.cs`：定义仪表盘读码器状态卡片模型。
- `Models/UiNotificationModel.cs`：定义 UI 通知展示模型，时间统一为本地时间语义。
- `Services/IAppNavigationService.cs`：定义页面导航抽象。
- `Services/AppNavigationService.cs`：统一解析页面键并切换当前页面视图模型。
- `Services/IDialogService.cs`：定义对话框服务抽象。
- `Services/DialogService.cs`：保留对话框入口，后续可接入窗口级 DialogHost。
- `Services/IToastNotificationService.cs`：定义通知提示服务抽象。
- `Services/ToastNotificationService.cs`：发布 UI 通知事件。
- `Services/IUiDispatcher.cs`：定义 UI 线程调度抽象。
- `Services/AvaloniaUiDispatcher.cs`：封装 Avalonia UI 线程投递与异步执行。
- `Services/PageKeys.cs`：统一维护页面键常量。
- `ViewModels/ViewModelBase.cs`：定义基于 `ObservableObject` 的视图模型基类。
- `ViewModels/MainWindowViewModel.cs`：维护主窗口标题、状态、导航集合、当前页面与启动/停止命令，不承载设备通信逻辑。
- `ViewModels/DashboardViewModel.cs`：提供仪表盘占位卡片数据。
- `ViewModels/ReaderMonitorViewModel.cs`：提供读码监控页面占位文案。
- `ViewModels/SettingsViewModel.cs`：提供设置页面占位文案。
- `ViewModels/LogsViewModel.cs`：提供日志页面占位文案。
- `Views/MainWindow.axaml`：定义 Shell 布局，包含左侧导航、顶部状态区、内容区与底部动画区。
- `Views/MainWindow.axaml.cs`：仅负责主窗口初始化与 ViewModel 注入。
- `Views/DashboardView.axaml`：定义仪表盘占位页面与状态卡片展示。
- `Views/DashboardView.axaml.cs`：提供仪表盘视图初始化入口。
- `Views/ReaderMonitorView.axaml`：定义读码监控占位页面。
- `Views/ReaderMonitorView.axaml.cs`：提供读码监控视图初始化入口。
- `Views/SettingsView.axaml`：定义系统设置占位页面。
- `Views/SettingsView.axaml.cs`：提供设置视图初始化入口。
- `Views/LogsView.axaml`：定义日志占位页面。
- `Views/LogsView.axaml.cs`：提供日志视图初始化入口。

### Contracts

- `Common/ApiResponse.cs`：定义通用响应契约。
- `Abstractions/Devices/IRfidReaderSession.cs`：定义读码器会话抽象。
- `Abstractions/Drivers/IRfidReaderDriverFactory.cs`：定义读码器驱动工厂抽象。
- `Abstractions/Time/ILocalClock.cs`：定义本地时钟抽象。
- `Enums/Devices/*.cs`：定义读码器厂商、协议、连接状态与能力枚举。
- `Events/Devices/*.cs`：定义读码器事件载荷与处理委托。
- `Models/Devices/*.cs`：定义共享设备配置模型。
- `Tags/RfidTagReadReportRequest.cs`：定义标签读取上报请求契约。

### Domain

- `Tags/RfidTag.cs`：定义 RFID 标签领域对象。

### Infrastructure

- `DependencyInjection/ServiceCollectionExtensions.cs`：注册 Infrastructure 服务与模拟驱动描述。
- `Drivers/Abstractions/RfidReaderDriverDescriptor.cs`：定义驱动描述与会话创建委托。
- `Drivers/Abstractions/RfidReaderDriverRegistry.cs`：实现驱动注册表行为。
- `Drivers/Factory/RfidReaderDriverFactory.cs`：根据设备配置创建读码器会话。
- `Drivers/Vendors/Simulated/SimulatedRfidReaderSession.cs`：提供模拟读码器会话骨架，不生成模拟标签。
- `Time/LocalClock.cs`：提供本地系统时间。

### Tests

- `RfidReadersOptionsTests.cs`：验证 Application 配置默认值。
- `MainWindowViewModelTests.cs`：验证主窗口默认导航、导航命令与启动/停止命令行为。
- `AppNavigationServiceTests.cs`：验证页面解析与中文异常。
- `ToastNotificationServiceTests.cs`：验证通知事件发布与本地时间戳生成。
- `TestServiceProviderFactory.cs`：统一构建 Avalonia 测试用服务提供器。
- `RfidReaderEnumsTests.cs`：验证 Contracts 枚举描述特性。
- `RfidReaderDriverRegistryTests.cs`：验证 Infrastructure 驱动注册表行为。

## UI 层底座能力

当前 UI 层底座已包含：

- MVVM 基类
- 主窗口 Shell
- 导航服务
- Dialog 服务
- Toast 通知服务
- UI Dispatcher
- Lottie 封装控件
- Dashboard / ReaderMonitor / Settings / Logs 页面占位

## 当前已实现能力

- 已明确 UI 私有接口与跨层共享接口的边界。
- 已通过 CI 防止 UI 私有接口被误迁移到 Contracts。
- 已通过 CI 防止非 UI 层引用 Avalonia.Services / ViewModels / Views。

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
- `Avalonia -> 真实厂商 SDK / TCP / 串口 / 数据库 / 外部业务系统`
- `Avalonia/ViewModels -> Infrastructure`

## 接口放置规则

1. 跨层共享接口必须放在 `Contracts/Abstractions`。
2. UI 私有接口允许放在 `Avalonia/Services`。
3. UI 私有接口包括：
   - `IAppNavigationService`
   - `IDialogService`
   - `IToastNotificationService`
   - `IUiDispatcher`
4. 当前仅由 Avalonia 使用、但未来可能跨层共享的接口，也应优先放在 `Contracts/Abstractions`。
5. UI 私有接口不得被 `Application`、`Infrastructure`、`Domain`、`Contracts` 引用。
6. 跨层业务接口不得放在 `Avalonia`。

## 验收命令

```bash
dotnet restore
dotnet build --configuration Release
dotnet test --configuration Release
```

## 本次更新内容

- 明确 `.github/copilot-instructions.md` 中 UI 私有接口与跨层共享接口的放置规则。
- 扩展 CI，防止 UI 私有接口误迁移到 Contracts，并阻断非 Avalonia 项目引用 Avalonia UI 命名空间。
- 更新 README 与架构文档，补齐 UI 私有接口边界说明。

## 后续可完善点

- 为后续新增跨层业务接口建立命名与目录审查清单，持续保持 `Contracts/Abstractions` 边界清晰。
- 继续补充 CI 对跨层命名空间引用的细粒度门禁，避免 UI 结构回退。
- 在保持当前禁止事项前提下，再逐步推进 UI 占位页面与只读状态流衔接。
