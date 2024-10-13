namespace NWEB01.Domain.DTOs
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
