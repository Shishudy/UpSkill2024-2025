using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace StoreLibrary.Models
{
	public class ProductDTO
	{
		public int ProductId { get; set; }
		public string Ean { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Category { get; set; } = null!;
		public string Description { get; set; } = null!;
		public double Price { get; set; }
		public double Discount { get; set; }
		public bool InStock { get; set; }
		public bool IsFavorite { get; set; } = false;
		public ImageDTO MainImage { get; set; } = null!;
	}
}
