using ExploreApp.DTO.NearbySearchDTOs;

namespace ExploreApp.Interfaces;

public interface ICachingService<T>
{
    public void CacheData(T data, string key);
}