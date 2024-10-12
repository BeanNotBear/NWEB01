using UserRole = ShareKernel.Enum.Role;

namespace NWEB01.Application.DTOs
{
	public class AddDoctorRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string Password { get; set; }
		public string Specialization { get; set; }
	}
}
