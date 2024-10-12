using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications.DoctorSpecification;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.PatientSpecification;


namespace NWEB01.Application.Services.PatientService
{
	public interface IPatientService
	{
		public Task<PaginationList<PatientDTO>> GetPatients(PatientSpeParam patientSpeParam);
		public Task<PatientDTO> AddPatient(AddPatientRequest addPatientRequest);
		public Task<PatientDTO> GetPatientById(Guid id, bool isInclude);
		public Task<PatientDTO> UpdatePatient(Guid id, UpdatePatientRequest updatePatientRequest);
		public Task<bool> DeletePatient(Guid id);
	}
}
