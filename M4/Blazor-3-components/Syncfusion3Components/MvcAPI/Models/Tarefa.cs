using System.ComponentModel.DataAnnotations;

namespace MvcAPI.Models
{
    public class Tarefa
    {
		[Key]
        public int Id { get; set; }
		public string Username { get; set; }
		public string Description { get; set; }
		public DateTime DOB { get; set; }
		public string Status { get; set; }
    }
}
