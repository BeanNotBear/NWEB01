namespace NWEB01.Domain.DTOs
{
	public class AddAppointmentRequest
	{
		public Guid PatientId { get; set; }
		public Guid DoctorId { get; set; }
		public DateTime Date { get; set; }
		public int Status { get; set; }
	}
}
