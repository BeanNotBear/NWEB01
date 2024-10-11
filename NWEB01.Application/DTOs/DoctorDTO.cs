using NWEB01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.DTOs
{
	public class DoctorDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public int Role { get; set; }
		public string Specialization { get; set; }
		public List<Appointment> DoctorAppointments { get; set; }
	}
}
