namespace NWEB01.Domain.Entities
{
	public class Appointment
	{
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
		public User Patient { get; set; }
		public User Doctor { get; set; }
       
    }
}
