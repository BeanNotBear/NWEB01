using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.DTOs
{
	public class AddPatientRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string Password { get; set; }
	}
}
