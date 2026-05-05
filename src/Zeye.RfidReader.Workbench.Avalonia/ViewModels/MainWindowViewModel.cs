using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zeye.RfidReader.Workbench.Avalonia.Models;
using Zeye.RfidReader.Workbench.Avalonia.Services;

namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 主窗口视图模型。
/// </summary>
public sealed partial class MainWindowViewModel : ViewModelBase, IDisposable
{
    private const string DefaultLottieAnimationPath = "avares://Zeye.RfidReader.Workbench.Avalonia/Assets/Animations/rfid-reader-loading.json";
    private const string StartedStatusText = "读码已启动";
    private const string StoppedStatusText = "读码已停止";

    private readonly IAppNavigationService _navigationService;
    private bool _isDisposed;

    /// <summary>
    /// 初始化主窗口视图模型。
    /// </summary>
    /// <param name="navigationService">应用导航服务。</param>
    public MainWindowViewModel(IAppNavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;

        Title = "Zeye RFID Reader Workbench";
        Subtitle = "RFID 读码器工作台 UI 基线。";
        StatusText = "UI 底座已启动。";
        LottieAnimationPath = DefaultLottieAnimationPath;

        NavigationItems =
        [
            new NavigationItemModel { Key = PageKeys.Dashboard, Title = "仪表盘", Description = "查看整体状态" },
            new NavigationItemModel { Key = PageKeys.ReaderMonitor, Title = "读码监控", Description = "查看读码器状态" },
            new NavigationItemModel { Key = PageKeys.Settings, Title = "系统设置", Description = "配置工作台参数" },
            new NavigationItemModel { Key = PageKeys.Logs, Title = "运行日志", Description = "查看运行日志" }
        ];

        _navigationService.NavigateTo(PageKeys.Dashboard);
    }

    /// <summary>
    /// 标题文本。
    /// </summary>
    [ObservableProperty]
    private string _title = string.Empty;

    /// <summary>
    /// 副标题文本。
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
    /// 当前页面视图模型。
    /// </summary>
    [ObservableProperty]
    private ViewModelBase? _currentViewModel;

    /// <summary>
    /// 是否正在运行。
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StartReadingCommand))]
    [NotifyCanExecuteChangedFor(nameof(StopReadingCommand))]
    private bool _isRunning;

    /// <summary>
    /// 导航项集合。
    /// </summary>
    public IReadOnlyList<NavigationItemModel> NavigationItems { get; }

    /// <summary>
    /// 导航到指定页面。
    /// </summary>
    /// <param name="pageKey">页面键。</param>
    [RelayCommand]
    private void Navigate(string pageKey)
    {
        _navigationService.NavigateTo(pageKey);
    }

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

    /// <summary>
    /// 处理当前页面变化。
    /// </summary>
    /// <param name="sender">事件发送方。</param>
    /// <param name="viewModel">当前页面视图模型。</param>
    private void OnCurrentViewModelChanged(object? sender, ViewModelBase? viewModel)
    {
        CurrentViewModel = viewModel;
    }

    /// <summary>
    /// 释放事件订阅。
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _navigationService.CurrentViewModelChanged -= OnCurrentViewModelChanged;
        _isDisposed = true;
    }
}
