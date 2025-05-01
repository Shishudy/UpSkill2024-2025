using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace WebStore.Services
{
    public class AddressInvoiceService
    {
        private readonly HttpClient _http;

		public AddressInvoiceService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

        // Accessor for GET: api/addresses/invoices/{fk_user}
        public async Task<List<Address>> GetInvoiceAddressByUserAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<Address>>($"api/addresses/invoices/{userId}");
        }

        // Accessor for POST: api/addresses/invoices/{fk_user}
        public async Task AddAddressToInvoiceAsync(string userId, Address address)
        {
            var response = await _http.PostAsJsonAsync($"api/addresses/invoices/{userId}", address);
            response.EnsureSuccessStatusCode();
        }

        // Accessor for DELETE: api/addresses/invoices/{addressId}
        public async Task DeleteAddressByIdAsync(int addressId)
        {
            var response = await _http.DeleteAsync($"api/addresses/invoices/{addressId}");
            response.EnsureSuccessStatusCode();
        }
    }
}