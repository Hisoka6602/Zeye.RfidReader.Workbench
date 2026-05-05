using Avalonia;
using Avalonia.Controls;

namespace Zeye.RfidReader.Workbench.Avalonia.Controls;

/// <summary>
/// RFID Lottie 动画视图。
/// </summary>
public sealed partial class RfidLottieView : UserControl
{
    /// <summary>
    /// 动画资源路径属性。
    /// </summary>
    public static readonly StyledProperty<string?> SourceProperty =
        AvaloniaProperty.Register<RfidLottieView, string?>(nameof(Source));

    /// <summary>
    /// 动画资源路径。
    /// </summary>
    public string? Source
    {
        get => GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    /// <summary>
    /// 初始化 RFID Lottie 动画视图。
    /// </summary>
    public RfidLottieView()
    {
        InitializeComponent();
    }
}
