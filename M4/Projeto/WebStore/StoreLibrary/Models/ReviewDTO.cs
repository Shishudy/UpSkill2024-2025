using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary.Models
{
	public class ReviewDTO
	{
		public int ReviewId { get; set; }

		public DateOnly ReviewDate { get; set; }

		public int Stars { get; set; }

		public string Comment { get; set; } = null!;

		public List<ImageDTO>? ImageDTOList { get; set; } = null!;
	}
}
