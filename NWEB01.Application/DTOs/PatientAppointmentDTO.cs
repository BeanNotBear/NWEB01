namespace NWEB01.Application.DTOs
{
	public class PatientAppointmentDTO
	{
		public DateTime Date { get; set; }
		public string Status { get; set; }
		public Guid DoctorID { get; set; }
		public string DoctorName { get; set; }
	}
}
