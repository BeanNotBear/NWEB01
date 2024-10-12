using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
