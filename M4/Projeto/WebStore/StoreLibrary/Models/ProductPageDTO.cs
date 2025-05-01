using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLibrary.DbModels;

namespace StoreLibrary.Models
{
	public class ProductPageDTO : ProductDTO
	{
		public List<ImageDTO> ImageDTOList { get; set; } = new List<ImageDTO>();
		public List<ReviewDTO> ReviewDTOList { get; set; } = new List<ReviewDTO>();
	}
}
