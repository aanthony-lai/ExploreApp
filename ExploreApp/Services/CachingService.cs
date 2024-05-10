using ExploreApp.DTO.NearbySearchDTOs;
using ExploreApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ExploreApp.Services;

public class CachingService<T>: ICachingService<T>
{
    private readonly IMemoryCache _cache;

    public CachingService(IMemoryCache cache, 
        IGooglePlacesService googlePlacesService)
    {
        _cache = cache;
    }

    public void CacheData(T data, string key)
    {
        ArgumentNullException.ThrowIfNull(data);
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
        
        _cache.Set(key, data, cacheOptions);
    }
}