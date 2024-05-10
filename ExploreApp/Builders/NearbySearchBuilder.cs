using ExploreApp.Interfaces;

namespace ExploreApp.Builders
{
	public class NearbySearchBuilder: INearbySearchBuilder
	{
		private string[] _types = [];
		private int _maxResults;
		private double _latitude;
		private double _longitude;
		private double _radius;
		private string _rankPreference = string.Empty;

		public NearbySearchBuilder()
		{
			_maxResults = 20;
			_latitude = 59.3318941;
			_longitude = 18.060944;
			_radius = 1000.0;
		}

		public NearbySearchBuilder setTypes(string type)
		{
			this._types = [ type ];
			return this;
		}

		public NearbySearchBuilder setRankPreference(string rankPreference)
		{
			this._rankPreference = rankPreference;
			return this;
		}

		public object Build()
		{
			return new
			{
				includedPrimaryTypes = this._types,
				maxResultCount = this._maxResults,
				locationRestriction = new
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
