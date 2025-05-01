using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace WebStore.Services
{
    public class InvoiceService
    {
        private readonly HttpClient _http;

		public InvoiceService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

        // Accessor for GET: api/invoices/{fk_user}
        public async Task<List<Invoice>> GetInvoicesByUserIDAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<Invoice>>($"api/invoices/{userId}");
        }

        // Accessor for GET: api/invoices/id/{id}
        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Invoice>($"api/invoices/id/{id}");
        }

        // Accessor for POST: api/invoices/{fk_user}
        public async Task AddInvoiceToPurchaseAsync(string userId, Invoice invoice)
        {
            var response = await _http.PostAsJsonAsync($"api/invoices/{userId}", invoice);
            response.EnsureSuccessStatusCode();
        }

        // Accessor for DELETE: api/invoices/{fk_user}
        public async Task DeleteInvoiceAsync(string userId)
        {
            var response = await _http.DeleteAsync($"api/invoices/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}