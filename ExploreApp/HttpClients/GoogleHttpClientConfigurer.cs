using ExploreApp.Interfaces;

namespace ExploreApp.HttpClients
{
	public class GoogleHttpClientConfigurer: IGoogleHttpClientConfigurer
	{
		private readonly IConfiguration _configuration;
		private const string ApiKeyHeader = "X-Goog-Api-Key";
		private const string FieldMaskHeader = "X-Goog-FieldMask";

		public GoogleHttpClientConfigurer(IConfiguration configuration) 
		{	
			_configuration = configuration;
		}

		public void ConfigureHeaders(HttpClient client, string serviceType)
		{
			var apiKey = _configuration.GetValue<string>("GoogleAPI:APIKey");
			var fieldMaskValue = _configuration.GetValue<string>($"GoogleAPI:{serviceType}");

			if (!client.DefaultRequestHeaders.Contains(ApiKeyHeader))
			{
				client.DefaultRequestHeaders.Add(ApiKeyHeader, apiKey);
			}
			if (!client.DefaultRequestHeaders.Contains(FieldMaskHeader))
			{
				client.DefaultRequestHeaders.Add(FieldMaskHeader, fieldMaskValue);
			}
		}
	}
}
