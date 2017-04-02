using System.ComponentModel.DataAnnotations;

namespace HappyBuddhaSite.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		public string WindowsIdentity { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public bool RememberMe { get; set; }
	}
}
