using ExploreApp.Interfaces;

namespace ExploreApp.Builders
{
	public class NearbySearchBuilder: INearbySearchBuilder
	{
		private string[] types;
		private int maxResults;
		private double latitude;
		private double longitude;
		private double radius;

		public NearbySearchBuilder()
		{
			types = [ "bar" ];
			maxResults = 20;
			latitude = 59.3318941;
			longitude = 18.060944;
			radius = 1000.0;
		}

		public object Build()
		{
			return new
			{
				includedTypes = this.types,
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
