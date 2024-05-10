using ExploreApp.DTO.NearbySearchDTOs;
using ExploreApp.DTO.TextSearchDTOs;
using ExploreApp.Interfaces;
using ExploreApp.NewFolder;
using System.Text.Json;


namespace ExploreApp.Services
{
	public class GooglePlacesService : IGooglePlacesService
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

		public async Task<NearbySearchDTO> NearbySearchAsync(string type)
		{
			const string serviceType = "NearbySearch";
			var client = _httpClient.CreateClient("GoogleClient");
			_googleHttpClientConfigurer.ConfigureHeaders(client, serviceType);

			var content = _nearbySearchBuilder
				.setTypes(type)
				.Build();
			
			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchNearby", content);
			var responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<NearbySearchDTO>(responseBody)
				?? new NearbySearchDTO();
		}

		public async Task<TextSearchDTO> TextSearchAsync(SearchModel searchModel)
		{
			const string serviceType = "TextSearch";
			var client = _httpClient.CreateClient("GoogleClient");
			_googleHttpClientConfigurer.ConfigureHeaders(client, serviceType);

			var content = _textSearchBuilder
				.setQuery(searchModel.textQuery)
				.setPrice(searchModel.selectedPrice)
				.setType(searchModel.selectedType)
				.Build();

			var response = await client.PostAsJsonAsync("https://places.googleapis.com/v1/places:searchText", content);
			var responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TextSearchDTO>(responseBody)
				?? new TextSearchDTO();
		}

		public string GetPlacePhoto(string placeName)
		{
			var apiKey = _configuration.GetValue<string>("GoogleAPI:APIKey");
			var imageUrl = $"https://places.googleapis.com/v1/{placeName}/media?key={apiKey}&maxWidthPx=1000";
			return imageUrl;
		}
	}
}
