using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.DTOs
{
	public class AppointmentDTO
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid DoctorId { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
	}
}
