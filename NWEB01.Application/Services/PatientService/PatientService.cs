using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.PatientSpecification;
using ShareKernel.CoreService;
using ShareKernel.Enum;
using System;
using System.Text;


namespace NWEB01.Application.Services.PatientService
{
	public class PatientService : IPatientService
	{
		private readonly IPatientRepository patientRepository;
		private readonly IDoctorRepository doctorRepository;
		private readonly IMapper mapper;

		public PatientService(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IMapper mapper)
		{
			this.patientRepository = patientRepository;
			this.doctorRepository = doctorRepository;
			this.mapper = mapper;
		}

		public async Task<PatientDTO> AddPatient(AddPatientRequest addPatientRequest)
		{
			var patientDomain = mapper.Map<User>(addPatientRequest);
			patientDomain.Role = (int)Role.Patient;
			var createdPatient = await patientRepository.Add(patientDomain);
			var patientDTO = mapper.Map<PatientDTO>(createdPatient);
			return patientDTO;
		}

		public async Task<bool> DeletePatient(Guid id)
		{
			var isDeleted = await patientRepository.Delete(id);
			return isDeleted;
		}

		public async Task<PaginationList<PatientDTO>> GetPatients(PatientSpeParam patientSpeParam)
		{
			var spec = new BaseSpecification<User>(x =>
				(string.IsNullOrWhiteSpace(patientSpeParam.Search) || x.Name.Contains(patientSpeParam.Search.EncodingUTF8())) &&
				(x.Role == (int)Role.Patient)
			);

			if (!patientSpeParam.IsDescending)
			{
				spec.AddOrderBy(x => x.Name);
			}
			else
			{
				spec.AddDescending(x => x.Name);
			}

			int skip = (patientSpeParam.pageIndex - 1) * patientSpeParam.pageSize;
			int take = patientSpeParam.pageSize;
			spec.ApplyPaging(take, skip);

			var patientDomains = await patientRepository.GetAll(spec);
			var result = mapper.Map<PaginationList<PatientDTO>>(patientDomains);
			return result;
		}

		public async Task<PatientDTO> GetPatientById(Guid id, bool isInclude)
		{
			User? patient;
			if (isInclude)
			{
				patient = await patientRepository.GetById(id, x => x.PatientAppointments);
				if (patient != null)
				{
					await JoinDoctor(patient);
				}
			}
			else
			{
				patient = await patientRepository.GetById(id, null);
			}
			var result = mapper.Map<PatientDTO>(patient);
			return result;
		}

		public async Task<PatientDTO> UpdatePatient(Guid id, UpdatePatientRequest updatePatientRequest)
		{
			var patientDomain = mapper.Map<User>(updatePatientRequest);
			patientDomain.Id = id;
			var updatedPatient = await patientRepository.Update(id, patientDomain);
			var patientDTO = mapper.Map<PatientDTO>(updatedPatient);
			return patientDTO;
		}

		private async Task JoinDoctor(User patient)
		{
			if (patient.PatientAppointments != null)
			{
				foreach (var appointment in patient.PatientAppointments)
				{
					appointment.Doctor = await doctorRepository.GetById(appointment.DoctorId, null);
				}
			}
		}
	}
}
