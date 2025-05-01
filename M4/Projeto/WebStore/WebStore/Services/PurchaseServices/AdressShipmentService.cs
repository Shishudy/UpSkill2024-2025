using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace WebStore.Services
{
    public class AddressShipmentService
    {
        private readonly HttpClient _http;

		public AddressShipmentService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

        // Accessor for GET: api/shipment-addresses/{fk_user}
        public async Task<List<Address>> GetAddressesByUserIDAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<Address>>($"api/shipment-addresses/{userId}");
        }

        // Accessor for POST: api/shipment-addresses/{fk_user}
        public async Task AddAddressToPurchaseAsync(string userId, Address address)
        {
            var response = await _http.PostAsJsonAsync($"api/shipment-addresses/{userId}", address);
            response.EnsureSuccessStatusCode();
        }
    }
}