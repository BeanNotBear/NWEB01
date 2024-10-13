using NWEB01.Domain.DTOs;
using NWEB01.Domain.Specifications;

namespace NWEB01.Application.Services.UserService
{
    public interface IDoctorService
    {
		public Task<PaginationList<DoctorDTO>> GetDoctors(DoctorSpeParam doctorSpeParam);
		public Task<DoctorDTO> AddDoctor(AddDoctorRequest addDoctorRequest);
		public Task<DoctorDTO> GetDoctorById(Guid id,bool isInclude);
		public Task<DoctorDTO> UpdateDoctor(Guid id, UpdateDoctorRequest updateDoctorRequest);
		public Task<bool> DeleteDoctor(Guid id);
	}
}
