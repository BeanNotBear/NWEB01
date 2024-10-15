using System.ComponentModel.DataAnnotations;

namespace NWEB01.Application.DTOs
{
	public class AddAppointmentRequest
	{
		[Required]
		public Guid PatientId { get; set; }

		[Required]
		public Guid DoctorId { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Date { get; set; }

		[Required]
		public int Status { get; set; }
	}
}
