using ExploreApp.Enums;

namespace ExploreApp.NewFolder
{
	public class SearchModel
	{
		public string textQuery { get; set; } = string.Empty;
		public string selectedType { get; set; } = string.Empty;
		public string selectedPrice { get; set; } = string.Empty;
		public string selectedLocation { get; set; } = string.Empty;
	}
}
