namespace StoreLibrary.DTOs.Campaigns
{ 
	public class AssociateProductsDTO
	{
		public int CampaignId { get; set; }
		public List<ProductDiscount> Products { get; set; } = new();
	}

}
