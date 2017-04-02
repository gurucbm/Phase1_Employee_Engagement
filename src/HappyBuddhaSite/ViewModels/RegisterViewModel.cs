using System;
using System.ComponentModel.DataAnnotations;

namespace HappyBuddhaSite.ViewModels
{
	public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public Guid AvatarId { get; set; }

        [Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string NickName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }

		public String Result { get; set; }
	}

}
