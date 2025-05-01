namespace StoreLibrary.DTOs.Product
{
	public class AddProductDTO
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public double Price { get; set; }
		public int Stock { get; set; }
		public int ImageId { get; set; }
		public int CategoryId { get; set; }
		public string Ean { get; set; } = null!;
	}

}
