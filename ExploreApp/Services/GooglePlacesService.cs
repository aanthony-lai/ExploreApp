using ExploreApp.DTO.NearbySearchDTOs;
using ExploreApp.DTO.TextSearchDTOs;
using ExploreApp.Interfaces;
using System.Text.Json;

namespace ExploreApp.Services
{
	public class GooglePlacesService: IGooglePlacesService
	{
		private readonly IHttpClientFactory _httpClient;
		private readonly IConfiguration _configuration;

		public GooglePlacesService(IHttpClientFactory httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}

		public async Task<NearbySearchDTO> NearbySearchAsync()
		{
			var client = _httpClient.CreateClient("GoogleClient");
			ConfigureGoogleClientHeaders(client, "nearbySearch");
			
			var content = new
			{
				includedTypes = new[] { "bar" },
				maxResultCount = 20,
				locationRestriction = new
				{
					circle = new
					{
						center = new { latitude = 59.3318941, longitude = 18.060944 },
						radius = 1000.0
					}
				}
			};

			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchNearby", content);
			string responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<NearbySearchDTO>(responseBody)
				?? new NearbySearchDTO();
		}

		public async Task<TextSearchDTO> TextSearchAsync(string textQuery, string type, string price)
		{
			var client = _httpClient.CreateClient("GoogleClient");
			ConfigureGoogleClientHeaders(client, "textSearch");
			
			var content = new
			{
				textQuery = textQuery,
				includedType = type,

				maxResultCount = 20,
				locationBias = new
				{
					circle = new
					{
						center = new { latitude = 59.3318941, longitude = 18.060944 },
						radius = 1000.0
					}
				}
			};

			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchText", content);
			string responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TextSearchDTO>(responseBody)
				?? new TextSearchDTO();
		}

		private void ConfigureGoogleClientHeaders(HttpClient client, string googleService)
		{
			var apiKeyHeader = "X-Goog-Api-Key";
			var fieldMaskHeader = "X-Goog-FieldMask";
			var apiKey = _configuration.GetValue<string>("GoogleAPIKey");
			var fieldMaskValue = "places.displayName,places.primaryTypeDisplayName,places.priceLevel,places.photos";
			
			if(googleService == "nearbySearch")
			{
				fieldMaskValue = "places.displayName,places.primaryTypeDisplayName,places.photos";
			}

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
