using ShareKernel.Enum;

namespace NWEB01.Application.DTOs
{
	public class DoctorDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string Specialization { get; set; }
		public List<AppointmentDTO> DoctorAppointments { get; set; }
	}
}
