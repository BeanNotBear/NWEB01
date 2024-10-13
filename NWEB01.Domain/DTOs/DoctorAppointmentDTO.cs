namespace NWEB01.Domain.DTOs
{
	public class DoctorAppointmentDTO
	{
        public DateTime Date { get; set; }
		public string Status { get; set; }
        public Guid PatientID { get; set; }
        public string PatientName { get; set; }
    }
}
