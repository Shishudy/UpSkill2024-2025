namespace StoreLibrary.DTOs.Auth
{
	public class RegisterModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Role { get; set; } = "User";
	}

}
