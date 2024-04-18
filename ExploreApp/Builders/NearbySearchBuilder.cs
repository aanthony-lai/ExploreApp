using ExploreApp.Interfaces;

namespace ExploreApp.Builders
{
	public class NearbySearchBuilder: INearbySearchBuilder
	{
		private string[] types = [];
		private int maxResults;
		private double latitude;
		private double longitude;
		private double radius;
		private string rankPreference = string.Empty;

		public NearbySearchBuilder()
		{
			maxResults = 20;
			latitude = 59.3318941;
			longitude = 18.060944;
			radius = 1000.0;
		}

		public NearbySearchBuilder setTypes(string type)
		{
			this.types = [ type ];
			return this;
		}

		public NearbySearchBuilder setRankPreference(string rankPreference)
		{
			this.rankPreference = rankPreference;
			return this;
		}

		public object Build()
		{
			return new
			{
				includedPrimaryTypes = this.types,
				maxResultCount = this.maxResults,
				locationRestriction = new
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
