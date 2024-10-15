using System.ComponentModel.DataAnnotations;
using UserRole = ShareKernel.Enum.Role;

namespace NWEB01.Application.DTOs
{
	public class AddDoctorRequest
	{
		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		[MinLength(5)]
		[MaxLength(255)]
		public string Email { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }

		[Required]
		[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$",
			ErrorMessage =
				"At least 8 characters and Must contain uppercase letters, lowercase letters, numbers and special characters")]
		public string Password { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(255)]
		public string Specialization { get; set; }
	}
}
