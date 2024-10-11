using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Specifications;
using ShareKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Mapping
{
	public class ProfilesMapping : Profile
	{
		public ProfilesMapping()
		{
			CreateMap<User, DoctorDTO>().ReverseMap();
			CreateMap<Appointment, AppointmentDTO>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((Status)src.Status).ToString())).ReverseMap();
			CreateMap<PaginationList<User>, PaginationList<DoctorDTO>>().ReverseMap();
			CreateMap<User, AddDoctorRequest>().ReverseMap();
		}
	}
}
