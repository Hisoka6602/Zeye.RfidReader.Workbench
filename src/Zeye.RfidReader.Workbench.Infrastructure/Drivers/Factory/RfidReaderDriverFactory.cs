using Zeye.RfidReader.Workbench.Contracts.Abstractions.Devices;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Drivers;
using Zeye.RfidReader.Workbench.Contracts.Models.Devices;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Abstractions;

namespace Zeye.RfidReader.Workbench.Infrastructure.Drivers.Factory;

/// <summary>
/// RFID 读码器驱动工厂。
/// </summary>
public sealed class RfidReaderDriverFactory : IRfidReaderDriverFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly RfidReaderDriverRegistry _registry;

    /// <summary>
    /// 初始化 RFID 读码器驱动工厂实例。
    /// </summary>
    /// <param name="serviceProvider">服务提供器。</param>
    /// <param name="registry">驱动注册表。</param>
    public RfidReaderDriverFactory(IServiceProvider serviceProvider, RfidReaderDriverRegistry registry)
    {
        _serviceProvider = serviceProvider;
        _registry = registry;
    }

    /// <inheritdoc />
    public IRfidReaderSession Create(RfidReaderDeviceOptions options)
    {
        var descriptor = _registry.GetRequired(options.VendorType, options.ProtocolType);
        return descriptor.CreateSession(_serviceProvider, options);
    }
}
