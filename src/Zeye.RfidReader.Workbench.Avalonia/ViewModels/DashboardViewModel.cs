using Zeye.RfidReader.Workbench.Avalonia.Models;

namespace Zeye.RfidReader.Workbench.Avalonia.ViewModels;

/// <summary>
/// 仪表盘视图模型。
/// </summary>
public sealed class DashboardViewModel : ViewModelBase
{
    /// <summary>
    /// 初始化仪表盘视图模型。
    /// </summary>
    public DashboardViewModel()
    {
        ReaderCards =
        [
            new ReaderStatusCardModel
            {
                ReaderCode = "RFID-SIM-001",
                ReaderName = "模拟 RFID 读码器",
                StatusText = "未连接",
                IsOnline = false
            }
        ];
    }

    /// <summary>
    /// 读码器状态卡片集合。
    /// </summary>
    public IReadOnlyList<ReaderStatusCardModel> ReaderCards { get; }
}
