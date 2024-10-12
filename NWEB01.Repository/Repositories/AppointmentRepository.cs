using Microsoft.EntityFrameworkCore;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Repository.Data;
using ShareKernel.Enum;

namespace NWEB01.Repository.Repositories
{
	public class AppointmentRepository : BaseRepository<Appointment, Guid>, IAppointmentRepository
	{

		private readonly AppDbContext dbContext;

		public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Appointment?> CancelAppointment(Guid id)
		{
			var existedAppointment = await dbContext.Appointments.FindAsync(id);
			if (existedAppointment != null)
			{
				existedAppointment.Status = (int)Status.Cancelled;
			}
			return existedAppointment;
		}
	}
}
