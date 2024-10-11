using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Repository.Data;

namespace NWEB01.Repository.Repositories
{
	public class PatientRepository : BaseRepository<User, Guid>, IPatientRepository
	{
		public PatientRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}
