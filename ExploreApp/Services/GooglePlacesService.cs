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
		private readonly IGoogleHttpClientConfigurer _googleHttpClientConfigurer;
		private readonly ITextSearchBuilder _textSearchBuilder;
		private readonly INearbySearchBuilder _nearbySearchBuilder;

		public GooglePlacesService(IHttpClientFactory httpClient, IConfiguration configuration,
			IGoogleHttpClientConfigurer googleHttpClientConfigurer, ITextSearchBuilder textSearchBuilder,
			INearbySearchBuilder nearbySearchBuilder)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_googleHttpClientConfigurer = googleHttpClientConfigurer;
			_textSearchBuilder = textSearchBuilder;
			_nearbySearchBuilder = nearbySearchBuilder;
		}

		public async Task<NearbySearchDTO> NearbySearchAsync()
		{
			const string serviceType = "NearbySearch";
			var client = _httpClient.CreateClient("GoogleClient");
			_googleHttpClientConfigurer.ConfigureHeaders(client, serviceType);
			
			var content = _nearbySearchBuilder.Build();

			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchNearby", content);
			string responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<NearbySearchDTO>(responseBody)
				?? new NearbySearchDTO();
		}

		public async Task<TextSearchDTO> TextSearchAsync(string textQuery, string type, string price)
		{
			const string serviceType = "TextSearch";
			var client = _httpClient.CreateClient("GoogleClient");
			_googleHttpClientConfigurer.ConfigureHeaders(client, serviceType);
			
			var content = _textSearchBuilder
				.setQuery(textQuery)
				.Build();

			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchText", content);
			string responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TextSearchDTO>(responseBody)
				?? new TextSearchDTO();
		}
	}
}
