using ExploreApp.Interfaces;

namespace ExploreApp.Builders
{
	public class TextSearchBuilder: ITextSearchBuilder
	{
		private string query = string.Empty;
		private string type = string.Empty;
		private string priceLevel = string.Empty;
		private int maxResults;
		private double latitude;
		private double longitude;
		private double radius;

		public TextSearchBuilder()
		{
			maxResults = 20;
			latitude = 59.3318941;
			longitude = 18.060944;
			radius = 1000.0;
		}
		
		public TextSearchBuilder setQuery(string query)
		{
			this.query = query;
			return this;
		}

		public TextSearchBuilder setType(string type) 
		{
			this.type = type; 
			return this;
		}

		public TextSearchBuilder setPrice(string priceLevel)
		{
			this.priceLevel = priceLevel;
			return this;
		}

		public object Build()
		{
			return new
			{
				textQuery = this.query,
				includedType = this.type,
				maxResultCount = this.maxResults,
				locationBias = new
				{
					circle = new
					{
						center = new { latitude = this.latitude, longitude = this.longitude },
						radius = this.radius
					}
				}
			};
		}
	}
}
