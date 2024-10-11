using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using NWEB01.Domain.Specifications.DoctorSpecification;
using ShareKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			var doctorDomain = await doctorRepository.GetAll(spec);
			var result = mapper.Map<PaginationList<DoctorDTO>>(doctorDomain);

			return result;
		}
	}
}
