using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.DoctorSpecification;

namespace NWEB01.Application.Services.UserService
{
    public interface IDoctorService
    {
		public Task<PaginationList<DoctorDTO>> GetDoctors(DoctorSpeParam doctorSpeParam);
	}
}
