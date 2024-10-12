using ShareKernel.Enum;


namespace NWEB01.Domain.Specifications
{
	public class AppointmentSpeParam : BaseSpeParam
	{
		public DateTime FromDate { get; set; } = DateTime.MinValue;
		public DateTime ToDate { get; set; } = DateTime.MaxValue;
		public List<Status> Statuses { get; set; } = new List<Status>() { Status.Scheduled, Status.Completed, Status.Cancelled};
	}
}
