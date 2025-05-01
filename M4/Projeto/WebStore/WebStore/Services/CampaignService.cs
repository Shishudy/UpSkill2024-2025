using System.Net.Http.Json;
using StoreLibrary.DTOs.Campaigns;

namespace WebStore.Services
{
	public class CampaignService
	{
		private readonly HttpClient _http;

		public CampaignService(IHttpClientFactory factory)
		{
			_http = factory.CreateClient("API");
		}

		public async Task<string> CreateCampaignAsync(CreateCampaignDTO dto)
		{
			var response = await _http.PostAsJsonAsync("api/Campaign", dto);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
				return result?["id"]?.ToString() ?? "0";
			}

			return "0";
		}

		public async Task<List<CampaignResponseDTO>> GetAllCampaignsAsync()
		{
			return await _http.GetFromJsonAsync<List<CampaignResponseDTO>>("api/Campaign");
		}

		public async Task<List<CampaignResponseDTO>> GetActiveCampaignsAsync()
		{
			return await _http.GetFromJsonAsync<List<CampaignResponseDTO>>("api/Campaign/active");
		}
	}
}
