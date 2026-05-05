using Zeye.RfidReader.Workbench.Avalonia.ViewModels;

namespace Zeye.RfidReader.Workbench.Avalonia.Services;

/// <summary>
/// 应用导航服务抽象。
/// </summary>
public interface IAppNavigationService
{
    /// <summary>
    /// 当前页面视图模型。
    /// </summary>
    ViewModelBase? CurrentViewModel { get; }

    /// <summary>
    /// 当前页面变化事件。
    /// </summary>
    event EventHandler<ViewModelBase?>? CurrentViewModelChanged;

    /// <summary>
    /// 导航到指定页面。
    /// </summary>
    /// <param name="pageKey">页面键。</param>
    void NavigateTo(string pageKey);
}
