using ExploreApp.Builders;

namespace ExploreApp.Interfaces
{
	public interface ITextSearchBuilder
	{
		public TextSearchBuilder setQuery(string query);
		public TextSearchBuilder setType(string type);
		public TextSearchBuilder setPrice(string priceLevel);
		public object Build();
	}
}
