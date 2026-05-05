using Avalonia.Controls;
using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Views;

/// <summary>
/// 主窗口。
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// 初始化主窗口实例。
    /// </summary>
    /// <param name="viewModel">主窗口视图模型。</param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        Closed += OnClosed;
    }

    /// <summary>
    /// 处理窗口关闭后的资源释放。
    /// </summary>
    /// <param name="sender">事件发送方。</param>
    /// <param name="e">事件参数。</param>
    private void OnClosed(object? sender, EventArgs e)
    {
        Closed -= OnClosed;

        if (DataContext is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
