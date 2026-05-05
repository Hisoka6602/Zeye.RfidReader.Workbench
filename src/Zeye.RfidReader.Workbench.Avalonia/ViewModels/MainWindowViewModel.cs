using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 主窗口视图模型。
/// </summary>
public sealed partial class MainWindowViewModel : ViewModelBase
{
    private const string DefaultLottieAnimationPath = "avares://Zeye.RfidReader.Workbench.Avalonia/Assets/Animations/rfid-reader-loading.json";
    private const string StartedStatusText = "读码已启动";
    private const string StoppedStatusText = "读码已停止";

    /// <summary>
    /// 初始化主窗口视图模型。
    /// </summary>
    public MainWindowViewModel()
    {
        Title = "Zeye RFID Reader Workbench";
        Subtitle = "当前演示界面展示 CI 门禁、契约迁移结果与 Lottie 动画占位。";
        StatusText = "已接入 Avalonia 12.0.2 对应的 Lottie 资源，后续可绑定实际设备状态。";
        LottieAnimationPath = DefaultLottieAnimationPath;
    }

    /// <summary>
    /// 标题文本。
    /// </summary>
    [ObservableProperty]
    private string _title = string.Empty;

    /// <summary>
    /// 主页说明文本。
    /// </summary>
    [ObservableProperty]
    private string _subtitle = string.Empty;

    /// <summary>
    /// 状态提示文本。
    /// </summary>
    [ObservableProperty]
    private string _statusText = string.Empty;

    /// <summary>
    /// Lottie 动画资源路径。
    /// </summary>
    [ObservableProperty]
    private string _lottieAnimationPath = string.Empty;

    /// <summary>
    /// 是否正在运行。
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StartReadingCommand))]
    [NotifyCanExecuteChangedFor(nameof(StopReadingCommand))]
    private bool _isRunning;

    /// <summary>
    /// 启动读码。
    /// </summary>
    /// <returns>异步任务。</returns>
    [RelayCommand(CanExecute = nameof(CanStartReading))]
    private Task StartReadingAsync()
    {
        IsRunning = true;
        StatusText = StartedStatusText;
        return Task.CompletedTask;
    }

    /// <summary>
    /// 判断是否可以启动读码。
    /// </summary>
    /// <returns>可以启动时返回 true。</returns>
    private bool CanStartReading()
    {
        return !IsRunning;
    }

    /// <summary>
    /// 停止读码。
    /// </summary>
    /// <returns>异步任务。</returns>
    [RelayCommand(CanExecute = nameof(CanStopReading))]
    private Task StopReadingAsync()
    {
        IsRunning = false;
        StatusText = StoppedStatusText;
        return Task.CompletedTask;
    }

    /// <summary>
    /// 判断是否可以停止读码。
    /// </summary>
    /// <returns>可以停止时返回 true。</returns>
    private bool CanStopReading()
    {
        return IsRunning;
    }
}
