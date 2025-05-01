namespace WebStore.Services
{
	public class FavouriteService
	{
		private readonly HttpClient _http;

		public FavouriteService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

		public async Task<string> UpdateFavourite(int productId)
		{
			var response = await _http.PostAsync($"api/favourites/{productId}", null);

			return await response.Content.ReadAsStringAsync();
		}
	}
}
