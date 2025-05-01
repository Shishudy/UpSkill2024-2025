using System;
using StoreLibrary.DbModels;


namespace WebStore.Services;

// Example in a Blazor service or a .NET HttpClient service class
public class CartService
{
    private readonly HttpClient _http;

		public CartService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

    // Accessor for GET: api/cart/{fk_user}
    public async Task<List<PurchaseProduct>> GetCartItemsByUserIDAsync(string userId)
    {
        return await _http.GetFromJsonAsync<List<PurchaseProduct>>($"{userId}/items");
    }

    // Accessor for DELETE: api/cart/{fk_user}
    public async Task DeletePurchaseAsync(string userId)
    {
        await _http.DeleteAsync($"api/cart/{userId}");
    }
}