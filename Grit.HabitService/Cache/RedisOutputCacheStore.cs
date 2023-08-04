using Microsoft.AspNetCore.OutputCaching;
using StackExchange.Redis;

namespace Grit.HabitService.Cache;

// <summary>
/// Class <c>RedisOutputCacheStore</c> Custom store class to replace InMemory cache used in Output Cache.
/// Implementing IOutputCacheStore methods using Redis 
/// Refer: https://www.youtube.com/watch?v=WeHZ_NMC-Jo&ab_channel=NickChapsas
/// </summary>
public class RedisOutputCacheStore : IOutputCacheStore
{
    private readonly IConnectionMultiplexer _connMultiplexer;

    public RedisOutputCacheStore(IConnectionMultiplexer connMultiplexer)
    {
        _connMultiplexer = connMultiplexer;
    }

    public async ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(key);

        var db = _connMultiplexer.GetDatabase();
        return await db.StringGetAsync(key);
    }

    public async ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(value);

        var db = _connMultiplexer.GetDatabase();

        foreach (var tag in tags ?? Array.Empty<string>())
        {
            await db.SetAddAsync(tag, key);
        }

        await db.StringSetAsync(key, value, validFor);
    }

    public async ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(tag);
        
        var db = _connMultiplexer.GetDatabase();

        var cachedKeys = await db.SetMembersAsync(tag);

        var keys = cachedKeys.
                        Select(x => (RedisKey)x.ToString())
                        .Concat(new[] { (RedisKey)tag })
                        .ToArray();

        await db.KeyDeleteAsync(keys);
    }
}