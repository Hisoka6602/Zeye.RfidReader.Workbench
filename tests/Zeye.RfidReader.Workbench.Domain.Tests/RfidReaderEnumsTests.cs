using System.ComponentModel;
using System.Reflection;
using Xunit;
using Zeye.RfidReader.Workbench.Domain.Devices;

namespace Zeye.RfidReader.Workbench.Domain.Tests;

/// <summary>
/// RFID 读码器枚举测试。
/// </summary>
public sealed class RfidReaderEnumsTests
{
    /// <summary>
    /// 厂商枚举项包含描述特性。
    /// </summary>
    [Fact]
    public void VendorType_ShouldHaveDescriptionAttribute()
    {
        var member = typeof(RfidReaderVendorType).GetMember(nameof(RfidReaderVendorType.Simulated)).Single();
        var description = member.GetCustomAttribute<DescriptionAttribute>();

        Assert.Equal("模拟RFID设备", description?.Description);
    }
}
