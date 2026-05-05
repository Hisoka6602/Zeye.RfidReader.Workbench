using Microsoft.Extensions.DependencyInjection;

namespace Zeye.RfidReader.Workbench.Application.DependencyInjection;

/// <summary>
/// Application 层服务注册扩展。
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 注册 RFID 读码器工作台 Application 层服务。
    /// </summary>
    /// <param name="services">服务集合。</param>
    /// <returns>服务集合。</returns>
    public static IServiceCollection AddRfidReaderWorkbenchApplication(this IServiceCollection services)
    {
        return services;
    }
}
