using ExploreApp.Interfaces;

namespace ExploreApp.HttpClients
{
	public class GoogleHttpClientConfigurer: IGoogleHttpClientConfigurer
	{
		private readonly IConfiguration _configuration;
		private readonly string apiKeyHeader = "X-Goog-Api-Key";
		private readonly string fieldMaskHeader = "X-Goog-FieldMask";

		public GoogleHttpClientConfigurer(IConfiguration configuration) 
		{	
			_configuration = configuration;
		}

		public void ConfigureHeaders(HttpClient client, string serviceType)
		{
			var apiKey = _configuration.GetValue<string>("GoogleAPI:APIKey");
			var fieldMaskValue = _configuration.GetValue<string>($"GoogleAPI:{serviceType}");

			if (!client.DefaultRequestHeaders.Contains(apiKeyHeader))
			{
				client.DefaultRequestHeaders.Add(apiKeyHeader, apiKey);
			}
			if (!client.DefaultRequestHeaders.Contains(fieldMaskHeader))
			{
				client.DefaultRequestHeaders.Add(fieldMaskHeader, fieldMaskValue);
			}
		}
	}
}
