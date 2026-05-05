using Xunit;
using Zeye.RfidReader.Workbench.Application.Options;

namespace Zeye.RfidReader.Workbench.Application.Tests;

/// <summary>
/// RFID 读码器配置测试。
/// </summary>
public sealed class RfidReadersOptionsTests
{
    /// <summary>
    /// 默认配置包含空设备集合。
    /// </summary>
    [Fact]
    public void Options_ShouldUseEmptyDevicesByDefault()
    {
        var options = new RfidReadersOptions();

        Assert.Equal("RfidReaders", RfidReadersOptions.SectionName);
        Assert.Empty(options.Devices);
    }
}
