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
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
