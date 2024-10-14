namespace NWEB01.Application.DTOs
{
	public class AppointmentDetailDTO
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid DoctorId { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
		public string PatientName { get; set; }
		public string DoctorName { get; set; }
	}
}
