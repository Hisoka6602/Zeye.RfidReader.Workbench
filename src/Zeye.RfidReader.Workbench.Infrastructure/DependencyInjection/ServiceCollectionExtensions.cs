using Microsoft.Extensions.DependencyInjection;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Drivers;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Time;
using Zeye.RfidReader.Workbench.Contracts.Enums.Devices;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Abstractions;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Factory;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Vendors.Simulated;
using Zeye.RfidReader.Workbench.Infrastructure.Time;

namespace Zeye.RfidReader.Workbench.Infrastructure.DependencyInjection;

/// <summary>
/// Infrastructure 层服务注册扩展。
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 注册 RFID 读码器工作台 Infrastructure 层服务。
    /// </summary>
    /// <param name="services">服务集合。</param>
    /// <returns>服务集合。</returns>
    public static IServiceCollection AddRfidReaderWorkbenchInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ILocalClock, LocalClock>();
        services.AddSingleton<IRfidReaderDriverFactory, RfidReaderDriverFactory>();
        services.AddSingleton(CreateRegistry());

        return services;
    }

    /// <summary>
    /// 创建默认驱动注册表。
    /// </summary>
    /// <returns>驱动注册表。</returns>
    private static RfidReaderDriverRegistry CreateRegistry()
    {
        var registry = new RfidReaderDriverRegistry();
        registry.Register(new RfidReaderDriverDescriptor
        {
            VendorType = RfidReaderVendorType.Simulated,
            ProtocolType = RfidReaderProtocolType.VendorSdk,
            DisplayName = "模拟RFID读码器",
            CreateSession = (_, options) => new SimulatedRfidReaderSession(options),
        });

        return registry;
    }
}
