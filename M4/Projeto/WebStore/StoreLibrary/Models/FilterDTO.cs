using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary.Models
{
	public class FilterDTO
	{
		public int? MinPrice { get; set; }
		public int? MaxPrice { get; set; }
		public bool? InStock { get; set; }
	}
}
