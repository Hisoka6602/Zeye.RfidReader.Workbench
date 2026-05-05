using Avalonia;

namespace Zeye.RfidReader.Workbench.Avalonia;

internal static class Program
{
    /// <summary>
    /// 启动 Avalonia 桌面应用。
    /// </summary>
    /// <param name="args">启动参数。</param>
    [STAThread]
    private static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    /// <summary>
    /// 构建 Avalonia 应用程序。
    /// </summary>
    /// <returns>Avalonia 应用构建器。</returns>
    private static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
    }
}
