namespace NWEB01.Application.DTOs
{
	public class PatientDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Specialization { get; set; }
		public List<PatientAppointmentDTO> PatientAppointments { get; set; }
	}
}
