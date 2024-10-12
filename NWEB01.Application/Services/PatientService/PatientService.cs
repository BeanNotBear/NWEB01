using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.DoctorSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.PatientService
{
	public class PatientService : IPatientService
	{
		public Task<PatientDTO> AddPatient(AddPatientRequest addPatientRequest)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeletePatient(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<PaginationList<PatientDTO>> GetPatient(DoctorSpeParam doctorSpeParam)
		{
			throw new NotImplementedException();
		}

		public Task<PatientDTO> GetPatientById(Guid id, bool isInclude)
		{
			throw new NotImplementedException();
		}

		public Task<PatientDTO> UpdatePatient(Guid id, UpdatePatientRequest updatePatientRequest)
		{
			throw new NotImplementedException();
		}
	}
}
