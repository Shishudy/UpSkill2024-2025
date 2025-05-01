namespace StoreLibrary.DTOs.Campaigns
{
	public class CreateCampaignDTO
	{
		public string Name { get; set; }
		public DateOnly DateStart { get; set; }
		public DateOnly DateEnd { get; set; }
	}
}
