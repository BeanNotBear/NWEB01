using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.DTOs
{
	public class PatientDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string Specialization { get; set; }
		public List<AppointmentDTO> PatientAppointments { get; set; }
	}
}
