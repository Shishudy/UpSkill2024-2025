using StoreLibrary.Models;

namespace WebStore.Services
{
	public class CategoryService
	{
		private readonly HttpClient _http;

		public CategoryService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

		public async Task<List<CategoryDTO>?> GetCategoryDtoListAsync()
		{
			var response = await _http.GetAsync("api/categories");

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
			}

			return null;
		}

		public async Task<CategoryDTO?> GetCategoryDtoByIdAsync(int categoryId)
		{
			var response = await _http.GetAsync($"api/categories/{categoryId}");

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<CategoryDTO>();
			}

			return null;
		}

		public async Task<string> CreateCategoryAsync(CategoryDTO categoryDto)
		{
			var response = await _http.PostAsJsonAsync("api/categories", categoryDto);

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> UpdateCategoryAsync(int categoryId, CategoryDTO categoryDto)
		{
			var response = await _http.PutAsJsonAsync($"api/categories/{categoryId}", categoryDto);
			 
			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> DeleteCategoryAsync(int categoryId)
		{
			var response = await _http.DeleteAsync($"api/categories/{categoryId}");

			return await response.Content.ReadAsStringAsync();
		}
	}
}
