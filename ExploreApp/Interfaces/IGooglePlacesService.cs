using ExploreApp.DTO.NearbySearchDTOs;
using ExploreApp.DTO.TextSearchDTOs;
using ExploreApp.NewFolder;

namespace ExploreApp.Interfaces
{
	public interface IGooglePlacesService
	{
		Task<NearbySearchDTO> NearbySearchAsync(string type);
		Task<TextSearchDTO> TextSearchAsync(SearchModel searchModel);
		public string GetPlacePhoto(string placeName);
	}
}
