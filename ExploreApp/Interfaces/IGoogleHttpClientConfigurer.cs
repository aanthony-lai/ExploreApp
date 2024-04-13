namespace ExploreApp.Interfaces
{
	public interface IGoogleHttpClientConfigurer
	{
		void ConfigureHeaders(HttpClient client, string serviceType);
	}
}
