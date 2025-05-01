namespace StoreLibrary.DTOs.Campaigns { 
	public class CampaignResponseDTO
	{
		public int PkCampaign { get; set; }
		public string Name { get; set; } = string.Empty;
		public DateOnly DateStart { get; set; }
		public DateOnly DateEnd { get; set; }
	}
}
