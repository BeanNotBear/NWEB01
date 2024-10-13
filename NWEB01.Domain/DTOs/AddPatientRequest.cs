namespace NWEB01.Domain.DTOs
{
	public class AddPatientRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Password { get; set; }
		public string Specialization { get; set; }
	}
}
