using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Repository.Repositories
{
	public class AppointmentRepository : BaseRepository<Appointment, Guid>, IAppointmentRepository
	{
		public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}
