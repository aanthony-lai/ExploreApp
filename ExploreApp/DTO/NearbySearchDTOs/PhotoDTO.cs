namespace ExploreApp.DTO.NearbySearchDTOs
{
	public class PhotoDTO
	{
		public string name { get; set; } = string.Empty;
		public int widthPx { get; set; } 
		public int heightPx { get; set; }
		public List<AuthorAttributionDTO> authorAttributions { get; set; } = new List<AuthorAttributionDTO>();
	}
}
