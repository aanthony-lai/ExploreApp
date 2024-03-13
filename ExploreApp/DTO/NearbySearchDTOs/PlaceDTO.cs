namespace ExploreApp.DTO.NearbySearchDTOs
{
	public class PlaceDTO
	{
		public string priceLevel { get; set; } = string.Empty;

		public DisplayNameDTO displayName { get; set; } = new DisplayNameDTO();
		public PrimaryTypeDisplayNameDTO primaryTypeDisplayName { get; set; } = new PrimaryTypeDisplayNameDTO();
		public List<PhotoDTO> photos { get; set; } = new List<PhotoDTO>();
	}
}
