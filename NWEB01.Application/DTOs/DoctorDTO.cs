using System.ComponentModel.DataAnnotations;

namespace NWEB01.Application.DTOs
{
	public class DoctorDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Specialization { get; set; }
		public List<DoctorAppointmentDTO> DoctorAppointments { get; set; }
	}
}
