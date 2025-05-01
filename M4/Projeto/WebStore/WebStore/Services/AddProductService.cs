using StoreLibrary.DTOs.Product;
using System.Net.Http.Json;

public class AddProductService
{
	private readonly HttpClient _http;

	public AddProductService(IHttpClientFactory factory)
	{
		_http = factory.CreateClient("API");
	}

	public async Task<bool> AddProductAsync(AddProductDTO productDto)
	{
		var response = await _http.PostAsJsonAsync("api/addproduct", productDto);
		return response.IsSuccessStatusCode;
	}
}
