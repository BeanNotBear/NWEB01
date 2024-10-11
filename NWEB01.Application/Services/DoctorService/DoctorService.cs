using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.DoctorSpecification;

namespace NWEB01.Application.Services.UserService
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository doctorRepository;
		private readonly IMapper mapper;

		public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
		{
			this.doctorRepository = doctorRepository;
			this.mapper = mapper;
		}

		public async Task<DoctorDTO> AddDoctor(AddDoctorRequest addDoctorRequest)
		{
			var doctorDomain = mapper.Map<User>(addDoctorRequest);
			await doctorRepository.Add(doctorDomain);
			var doctorDTO = mapper.Map<DoctorDTO>(doctorDomain);
			return doctorDTO;
		}

		public async Task<DoctorDTO> GetDoctorById(Guid id, bool isInclude)
		{
			User doctorDomain;

			if (isInclude)
			{
				// Include related DoctorAppointments
				doctorDomain = await doctorRepository.GetById(id, d => d.DoctorAppointments);
			}
			else
			{
				// Get the doctor without related appointments
				doctorDomain = await doctorRepository.GetById(id, null);
			}
			var doctorDTO = mapper.Map<DoctorDTO>(doctorDomain);
			return doctorDTO;
		}

		public async Task<PaginationList<DoctorDTO>> GetDoctors(DoctorSpeParam doctorSpeParam)
		{
			var spec = new BaseSpecification<User>(x =>
				(string.IsNullOrEmpty(doctorSpeParam.Search) || x.Name.Contains(doctorSpeParam.Search)) &&
				(x.Role == 0) &&
				(!(doctorSpeParam.Specialization != null) || x.Specialization == doctorSpeParam.Specialization)

			);

			int skip = (doctorSpeParam.pageIndex - 1) * doctorSpeParam.pageSize;
			int take = doctorSpeParam.pageSize;

			spec.ApplyPaging(take, skip);
			if (doctorSpeParam.IsDescending)
			{
				spec.AddOrderBy(x => x.Name);
			}
			else
			{
				spec.AddDescending(x => x.Name);
			}

			if (doctorSpeParam.IsIncludeAppoitment)
			{
				spec.AddInclude(x => x.DoctorAppointments);
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
			var doctorDTO = mapper.Map<DoctorDTO>(updatedDoctor);
			return doctorDTO;
		}
	}
}
