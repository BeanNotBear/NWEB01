using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }
		public string Specialization { get; set; }
        public List<Appointment> PatientAppointments { get; set; }
		public List<Appointment> DoctorAppointments { get; set; }
	}
}
