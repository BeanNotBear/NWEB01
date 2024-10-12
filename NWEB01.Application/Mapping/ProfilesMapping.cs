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
			CreateMap<Appointment, DoctorAppointmentDTO>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((Status)src.Status).ToString()))
				.ForMember(dest => dest.PatientID, opt => opt.MapFrom(src => src.PatientId))
				.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
				.ReverseMap();
			CreateMap<Appointment, PatientAppointmentDTO>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((Status)src.Status).ToString()))
				.ForMember(dest => dest.DoctorID, opt => opt.MapFrom(src => src.DoctorId))
				.ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
				.ReverseMap();
			CreateMap<PaginationList<User>, PaginationList<DoctorDTO>>().ReverseMap();
			CreateMap<User, AddDoctorRequest>().ReverseMap();
			CreateMap<User, UpdateDoctorRequest>().ReverseMap();
			CreateMap<User, AddPatientRequest>().ReverseMap();
			CreateMap<User, UpdatePatientRequest>().ReverseMap();
			CreateMap<User, PatientDTO>().ReverseMap();
			CreateMap<PaginationList<User>, PaginationList<PatientDTO>>().ReverseMap();
			CreateMap<Appointment, AddAppointmentRequest>().ReverseMap();
			CreateMap<Appointment, UpdateAppointmentRequest>().ReverseMap();
			CreateMap<Appointment, AppointmentDTO>().ReverseMap();        
			CreateMap<PaginationList<Appointment>, PaginationList<AppointmentDTO>>().ReverseMap();
			CreateMap<Appointment, AppointmentDetailDTO>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((Status)src.Status).ToString()))
				.ReverseMap();
		}
	}
}
