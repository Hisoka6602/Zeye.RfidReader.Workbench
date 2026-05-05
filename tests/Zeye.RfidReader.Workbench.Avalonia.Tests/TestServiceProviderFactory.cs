using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.DependencyInjection;
using Zeye.RfidReader.Workbench.Infrastructure.DependencyInjection;

namespace Zeye.RfidReader.Workbench.Avalonia.Tests;

/// <summary>
/// Avalonia 测试服务提供器工厂。
/// </summary>
internal static class TestServiceProviderFactory
{
    /// <summary>
    /// 创建测试服务提供器。
    /// </summary>
    /// <returns>服务提供器。</returns>
    public static ServiceProvider Create()
    {
        var services = new ServiceCollection();
        services.AddRfidReaderWorkbenchInfrastructure();
        services.AddRfidReaderWorkbenchAvalonia();
        return services.BuildServiceProvider();
    }
}
