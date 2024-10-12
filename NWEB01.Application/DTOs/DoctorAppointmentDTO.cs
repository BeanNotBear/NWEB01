using ShareKernel.Enum;

namespace NWEB01.Application.DTOs
{
	public class DoctorAppointmentDTO
	{
        public DateTime Date { get; set; }
		public string Status { get; set; }
        public Guid PatientID { get; set; }
        public string PatientName { get; set; }
    }
}
