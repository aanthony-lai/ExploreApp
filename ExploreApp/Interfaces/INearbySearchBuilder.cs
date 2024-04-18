using ExploreApp.Builders;

namespace ExploreApp.Interfaces
{
	public interface INearbySearchBuilder
	{
		public object Build();
		public NearbySearchBuilder setTypes(string type);
		public NearbySearchBuilder setRankPreference(string rankPreference);
	}
}
