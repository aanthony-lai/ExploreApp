using ExploreApp.DTO.NearbySearchDTOs;
using ExploreApp.DTO.TextSearchDTOs;

namespace ExploreApp.Interfaces
{
	public interface IGooglePlacesService
	{
		Task<NearbySearchDTO> NearbySearchAsync();
		Task<TextSearchDTO> TextSearchAsync(string textQuery, string type, string price);
	}
}
