using Microsoft.Extensions.DependencyInjection;

namespace Zeye.RfidReader.Workbench.Avalonia.DependencyInjection;

/// <summary>
/// Avalonia 层服务注册扩展。
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 注册 RFID 读码器工作台 Avalonia 层服务。
    /// </summary>
    /// <param name="services">服务集合。</param>
    /// <returns>服务集合。</returns>
    public static IServiceCollection AddRfidReaderWorkbenchAvalonia(this IServiceCollection services)
    {
        return services;
    }
}
