using StoreLibrary.Models;

namespace WebStore.Services
{
	public class ProductService
	{
		private readonly HttpClient _http;

		public ProductService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

		public async Task<List<ProductDTO>?> GetProductDtoListAsync(FilterDTO? filter = null, string? category = null, string? search = null)
		{
			string url = "api/products/category";

			if (category != null && search == null)
				url += $"/{category}";

			var queryParams = new List<string>();

			if (search != null)
				queryParams.Add($"search={search}");
			else
			{
				if (filter != null)
				{
					if (filter.MinPrice != null)
						queryParams.Add($"minPrice={filter.MinPrice}");

					if (filter.MaxPrice != null)
						queryParams.Add($"maxPrice={filter.MaxPrice}");

					if (filter.InStock != null)
						queryParams.Add($"inStock={filter.InStock.Value.ToString().ToLower()}");
				}
			}

			if (queryParams.Count > 0)
			{
				url += "?" + string.Join("&", queryParams);
			}

			var response = await _http.GetAsync(url);

			if (response.IsSuccessStatusCode)
				return await response.Content.ReadFromJsonAsync<List<ProductDTO>>();

			return null;
		}

		public async Task<ProductPageDTO?> GetProductPageDtoAsync(string ean)
		{
			var response = await _http.GetAsync($"api/products/product/{ean}");

			if (response.IsSuccessStatusCode)
				return await response.Content.ReadFromJsonAsync<ProductPageDTO>();

			return null;
		}

		public async Task<List<ProductDTO>> GetAllProductsAsync()
		{
			return await _http.GetFromJsonAsync<List<ProductDTO>>("api/product") ?? new();
		}

		public async Task AddItemToCartAsync(string fk_user, int productId, int quantity)
		{
			var cartItem = new { ProductId = productId, Quantity = quantity };
			var response = await _http.PostAsJsonAsync($"api/cart/{fk_user}/items", cartItem);
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception("Failed to add item to cart.");
			}
		}

		public async Task RemoveItemFromCartAsync(string fk_user, int productId)
		{
			var response = await _http.DeleteAsync($"api/cart/{fk_user}/items/{productId}");
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception("Failed to remove item from cart.");
			}
		}

		//public async Task AddProductAsync(Product product)
		//{
		//	await _http.PostAsJsonAsync("api/products", product);
		//}

		//public async Task UpdateProductAsync(Product product)
		//{
		//	await _http.PutAsJsonAsync($"api/products/{product.Ean}", product);
		//}

		//public async Task RemoveUpdateAsync(Product product)
		//{
		//	await _http.DeleteAsync($"api/products/{product.Ean}");
		//}
	}
}
