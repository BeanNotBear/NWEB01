namespace NWEB01.Application.Exceptions
{
	public class DoctorNotFoundException : NotFoundException
	{
		public DoctorNotFoundException(string? message) : base(message)
		{
		}
	}
}
