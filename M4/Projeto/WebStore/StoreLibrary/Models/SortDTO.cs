using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary.Models
{
	public enum SortOption
	{
		None,
		LowestPrice,
		HighestPrice,
		Category,
		InStock
	}

	public class SortDTO
	{
		public SortOption SortBy { get; set; }
	}
}
