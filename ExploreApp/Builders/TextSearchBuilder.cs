using ExploreApp.Interfaces;

namespace ExploreApp.Builders
{
	public class TextSearchBuilder: ITextSearchBuilder
	{
		// private string query = string.Empty;
		// private string type = string.Empty;
		// private string priceLevel = string.Empty;
		// private int maxResults;
		// private double latitude;
		// private double longitude;
		// private double radius;
		private string _query = string.Empty;
		private string _type = string.Empty;
		private string _priceLevel = string.Empty;
		private int _maxResults;
		private double _latitude;
		private double _longitude;
		private double _radius;

		public TextSearchBuilder()
		{
			_maxResults = 20;
			_latitude = 59.3318941;
			_longitude = 18.060944;
			_radius = 1000.0;
		}
		
		public TextSearchBuilder setQuery(string query)
		{
			this._query = query;
			return this;
		}

		public TextSearchBuilder setType(string type) 
		{
			this._type = type; 
			return this;
		}

		public TextSearchBuilder setPrice(string priceLevel)
		{
			this._priceLevel = priceLevel;
			return this;
		}

		public object Build()
		{
			return new
			{
				textQuery = this._query,
				includedType = this._type,
				maxResultCount = this._maxResults,
				locationBias = new
				{
					circle = new
					{
						center = new { latitude = this._latitude, longitude = this._longitude },
						radius = this._radius
					}
				}
			};
		}
	}
}
