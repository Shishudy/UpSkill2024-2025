using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace WebStore.Services
{
    public class PurchaseService
    {
        private readonly HttpClient _http;

		public PurchaseService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

        // Accessor for GET: api/cart/{fk_user}
        public async Task<Purchase> GetCartByUserIDAsync(string userId)
        {
            return await _http.GetFromJsonAsync<Purchase>($"api/cart/{userId}");
        }

        // Accessor for DELETE: api/cart/{fk_user}
        public async Task DeletePurchaseAsync(string userId)
        {
            var response = await _http.DeleteAsync($"api/cart/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}