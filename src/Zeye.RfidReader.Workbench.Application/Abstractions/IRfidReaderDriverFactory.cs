using Zeye.RfidReader.Workbench.Application.Options;
using Zeye.RfidReader.Workbench.Domain.Abstractions;

namespace Zeye.RfidReader.Workbench.Application.Abstractions;

/// <summary>
/// RFID 读码器驱动工厂抽象。
/// </summary>
public interface IRfidReaderDriverFactory
{
    /// <summary>
    /// 创建 RFID 读码器会话。
    /// </summary>
    /// <param name="options">读码器设备配置。</param>
    /// <returns>RFID 读码器会话。</returns>
    IRfidReaderSession Create(RfidReaderDeviceOptions options);
}
