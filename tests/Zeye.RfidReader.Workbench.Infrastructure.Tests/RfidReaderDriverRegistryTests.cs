using Xunit;
using Zeye.RfidReader.Workbench.Contracts.Abstractions.Devices;
using Zeye.RfidReader.Workbench.Contracts.Enums.Devices;
using Zeye.RfidReader.Workbench.Contracts.Models.Devices;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Abstractions;
using Zeye.RfidReader.Workbench.Infrastructure.Drivers.Vendors.Simulated;

namespace Zeye.RfidReader.Workbench.Infrastructure.Tests;

/// <summary>
/// RFID 读码器驱动注册表测试。
/// </summary>
public sealed class RfidReaderDriverRegistryTests
{
    /// <summary>
    /// 注册驱动后可以按厂商和协议获取。
    /// </summary>
    [Fact]
    public void GetRequired_ShouldReturnRegisteredDescriptor()
    {
        var registry = new RfidReaderDriverRegistry();
        var descriptor = CreateDescriptor();

        registry.Register(descriptor);

        Assert.Same(descriptor, registry.GetRequired(RfidReaderVendorType.Simulated, RfidReaderProtocolType.VendorSdk));
    }

    /// <summary>
    /// 重复注册相同厂商和协议时抛出中文异常。
    /// </summary>
    [Fact]
    public void Register_ShouldThrowChineseExceptionWhenDuplicate()
    {
        var registry = new RfidReaderDriverRegistry();
        registry.Register(CreateDescriptor());

        var exception = Assert.Throws<InvalidOperationException>(() => registry.Register(CreateDescriptor()));

        Assert.Contains("RFID 读码器驱动重复注册", exception.Message);
    }

    /// <summary>
    /// 未注册驱动时抛出中文异常。
    /// </summary>
    [Fact]
    public void GetRequired_ShouldThrowChineseExceptionWhenMissing()
    {
        var registry = new RfidReaderDriverRegistry();

        var exception = Assert.Throws<InvalidOperationException>(() => registry.GetRequired(RfidReaderVendorType.Impinj, RfidReaderProtocolType.VendorSdk));

        Assert.Contains("未找到 RFID 读码器驱动", exception.Message);
    }

    /// <summary>
    /// 创建测试驱动描述。
    /// </summary>
    /// <returns>驱动描述。</returns>
    private static RfidReaderDriverDescriptor CreateDescriptor()
    {
        return new RfidReaderDriverDescriptor
        {
            VendorType = RfidReaderVendorType.Simulated,
            ProtocolType = RfidReaderProtocolType.VendorSdk,
            DisplayName = "模拟RFID读码器",
            CreateSession = (_, options) => CreateSession(options),
        };
    }

    /// <summary>
    /// 创建模拟会话。
    /// </summary>
    /// <param name="options">设备配置。</param>
    /// <returns>模拟会话。</returns>
    private static IRfidReaderSession CreateSession(RfidReaderDeviceOptions options)
    {
        return new SimulatedRfidReaderSession(options);
    }
}
