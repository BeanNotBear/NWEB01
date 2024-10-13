using AutoMapper;
using NWEB01.Domain.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using ShareKernel.CoreService;
using ShareKernel.Enum;

namespace NWEB01.Application.Services.UserService
{
    public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository doctorRepository;
		private readonly IPatientRepository patientRepository;
		private readonly IMapper mapper;

		public DoctorService(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IMapper mapper)
		{
			this.doctorRepository = doctorRepository;
			this.patientRepository = patientRepository;
			this.mapper = mapper;
		}

		public async Task<DoctorDTO> AddDoctor(AddDoctorRequest addDoctorRequest)
		{
			var doctorDomain = mapper.Map<User>(addDoctorRequest);
			await doctorRepository.Add(doctorDomain);
			var doctorDTO = mapper.Map<DoctorDTO>(doctorDomain);
			return doctorDTO;
		}

		public Task<bool> DeleteDoctor(Guid id)
		{
			var isDeleted = doctorRepository.Delete(id);
			return isDeleted;
		}

		public async Task<DoctorDTO> GetDoctorById(Guid id, bool isInclude)
		{
			User? doctorDomain;
			var spec = new BaseSpecification<User>(x => x.Role == (int)Role.Doctor);
			if (isInclude)
			{
				spec.AddInclude(d => d.DoctorAppointments);
				// Include related DoctorAppointments
				doctorDomain = await doctorRepository.GetById(id, spec);
				if(doctorDomain != null)
				{
					await JoinPatient(doctorDomain);
				}
			}
			else
			{
				// Get the doctor without related appointments
				doctorDomain = await doctorRepository.GetById(id, spec);
			}
			var doctorDto = mapper.Map<DoctorDTO>(doctorDomain);
			return doctorDto;
		}

		public async Task<PaginationList<DoctorDTO>> GetDoctors(DoctorSpeParam doctorSpeParam)
		{
			var spec = new BaseSpecification<User>(x =>
				(string.IsNullOrEmpty(doctorSpeParam.Search) || x.Name.Contains(doctorSpeParam.Search.EncodingUTF8())) &&
				(x.Role == 0) &&
				(doctorSpeParam.Specialization == null || x.Specialization == doctorSpeParam.Specialization)

			);

			var skip = (doctorSpeParam.pageIndex - 1) * doctorSpeParam.pageSize;
			var take = doctorSpeParam.pageSize;

			spec.ApplyPaging(take, skip);
			if (!doctorSpeParam.IsDescending)
			{
				spec.AddOrderBy(x => x.Name);
			}
			else
			{
				spec.AddDescending(x => x.Name);
			}

			var doctorDomain = await doctorRepository.GetAll(spec);

			var result = mapper.Map<PaginationList<DoctorDTO>>(doctorDomain);

			return result;
		}

		public async Task<DoctorDTO> UpdateDoctor(Guid id, UpdateDoctorRequest updateDoctorRequest)
		{
			var doctorDomain = mapper.Map<User>(updateDoctorRequest);
			doctorDomain.Id = id;
			var updatedDoctor = await doctorRepository.Update(id, doctorDomain);
			var doctorDto = mapper.Map<DoctorDTO>(updatedDoctor);
			return doctorDto;
		}

		private async Task JoinPatient(User user)
		{
			if (user.DoctorAppointments != null)
			{
				foreach (var appointment in user.DoctorAppointments)
				{
					var spec = new BaseSpecification<User>(x => x.Role == (int)Role.Patient);
					appointment.Patient = await patientRepository.GetById(appointment.PatientId, spec);
				}
			}
		}
	}
}
