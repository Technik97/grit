using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Grit.HabitService.Cache;

// <summary>
/// Class <c>RedisOutputCacheStore</c> Creating Custom OutputCache.
/// Configuration for using RedisOutputCacheStore as IOutputCacheStore
/// Refer: https://www.youtube.com/watch?v=WeHZ_NMC-Jo&ab_channel=NickChapsas
/// </summary>
public static class RedisOutputCacheServiceCollectionExtensions
{
    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOutputCache();

        services.RemoveAll<IOutputCacheStore>();

        services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

        return services;
    }

    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.Configure(configureOptions);
        services.AddOutputCache();

        services.RemoveAll<IOutputCacheStore>();
        services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

        return services;
    }
}