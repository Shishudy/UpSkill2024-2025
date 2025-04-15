using System.ComponentModel.DataAnnotations;

namespace Syncfusion3Components.Models
{
    public class Tarefa
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "User required")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Description required")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Date required")]
		public DateTime DOB { get; set; } = new DateTime();
		public string Status { get; set; }
    }
}
