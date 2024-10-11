using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications.DoctorSpecification;
using NWEB01.Domain.Specifications;


namespace NWEB01.Application.Services.PatientService
{
	public interface IPatientService
	{
		public Task<PaginationList<PatientDTO>> GetPatient(DoctorSpeParam doctorSpeParam);
		public Task<PatientDTO> AddPatient(AddPatientRequest addPatientRequest);
		public Task<PatientDTO> GetPatientById(Guid id, bool isInclude);
		public Task<PatientDTO> UpdatePatient(Guid id, UpdatePatientRequest updatePatientRequest);
		public Task<bool> DeletePatient(Guid id);
	}
}
