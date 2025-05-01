using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace WebStore.Services
{
    public class CardService
    {
		private readonly HttpClient _http;

		public CardService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

        // Accessor for GET: api/cards/{fk_user}
        public async Task<List<Card>> GetCardsByUserIDAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<Card>>($"api/cards/{userId}");
        }

        // Accessor for POST: api/cards/{fk_user}
        public async Task AddCardToPurchaseAsync(string userId, Card card)
        {
            var response = await _http.PostAsJsonAsync($"api/cards/{userId}", card);
            // response.EnsureSuccessStatusCode();
        }

        // Accessor for DELETE: api/cards/{cardId}
        public async Task DeleteCardByIdAsync(int cardId)
        {
            var response = await _http.DeleteAsync($"api/cards/{cardId}");
            // response.EnsureSuccessStatusCode();
        }
    }
}