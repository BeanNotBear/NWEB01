namespace NWEB01.Application.Exceptions
{
	public class AppointmentNotFoundException : NotFoundException
	{
		public AppointmentNotFoundException(string? message) : base(message)
		{
		}
	}
}
