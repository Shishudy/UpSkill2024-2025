using System.Net.Http.Headers;
using StoreLibrary.Models;

public class ImageService
{
	private readonly HttpClient _http;

	public ImageService(IHttpClientFactory factory)
	{
		_http = factory.CreateClient("API");
	}

	public async Task<List<ImageDTO>?> GetImagesAsync(ImageCategory category, int ownerId)
	{
		var response = await _http.GetAsync($"api/images/{category}/{ownerId}");

		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<List<ImageDTO>>();
		}

		return null;
	}

	public async Task<string> UploadImageAsync(ImageCategory category, int ownerId, Stream fileStream, string originalFileName, string? name = null)
	{
		var content = new MultipartFormDataContent();

		var fileContent = new StreamContent(fileStream);
		fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

		content.Add(fileContent, "file", originalFileName);

		if (!string.IsNullOrWhiteSpace(name))
		{
			content.Add(new StringContent(name), "name");
		}

		var response = await _http.PostAsync($"api/images/{category}/{ownerId}", content);

		return await response.Content.ReadAsStringAsync();
	}

	//public async Task<string?> UpdateImageAsync(ImageCategory category, int ownerId, int imageId, Stream fileStream, string originalFileName, string? name = null)
	//{
	//	var content = new MultipartFormDataContent();

	//	var fileContent = new StreamContent(fileStream);
	//	fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

	//	content.Add(fileContent, "file", originalFileName);

	//	if (!string.IsNullOrWhiteSpace(name))
	//	{
	//		content.Add(new StringContent(name), "name");
	//	}

	//	var response = await _http.PutAsync($"api/images/{category}/{ownerId}/{imageId}", content);

	//	return await response.Content.ReadFromJsonAsync<string>();
	//}

	public async Task<bool> DeleteImageAsync(int imageId)
	{
		var response = await _http.DeleteAsync($"api/images/{imageId}");
		return response.IsSuccessStatusCode;
	}
}
