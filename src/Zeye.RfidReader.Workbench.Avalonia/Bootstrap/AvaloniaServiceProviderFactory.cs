using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Application.DependencyInjection;
using Zeye.RfidReader.Workbench.Avalonia.DependencyInjection;
using Zeye.RfidReader.Workbench.Infrastructure.DependencyInjection;

namespace Zeye.RfidReader.Workbench.Avalonia.Bootstrap;

/// <summary>
/// Avalonia 服务提供器工厂。
/// </summary>
public static class AvaloniaServiceProviderFactory
{
    /// <summary>
    /// 创建服务提供器。
    /// </summary>
    /// <returns>服务提供器。</returns>
    public static ServiceProvider Create()
    {
        var services = new ServiceCollection();
        services.AddRfidReaderWorkbenchApplication();
        services.AddRfidReaderWorkbenchInfrastructure();
        services.AddRfidReaderWorkbenchAvalonia();

        return services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });
    }
}
