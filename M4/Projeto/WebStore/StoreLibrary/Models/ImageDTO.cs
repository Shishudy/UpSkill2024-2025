using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary.Models
{
	public class ImageDTO
	{
		public int ImageId { get; set; }
		public string PathImg { get; set; } = null!;
		public string? Name { get; set; }
	}
}
