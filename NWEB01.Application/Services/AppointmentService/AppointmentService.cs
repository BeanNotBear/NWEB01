using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using ShareKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.AppointmentService
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository appointmentRepository;
		private readonly IMapper mapper;

		public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
		{
			this.appointmentRepository = appointmentRepository;
			this.mapper = mapper;
		}

		public async Task<AppointmentDTO> AddAppointment(AddAppointmentRequest addAppointmentRequest)
		{
			var appointmentDomain = mapper.Map<Appointment>(addAppointmentRequest);
			var createdAppointment = await appointmentRepository.Add(appointmentDomain);
			var appointmentDTO = mapper.Map<AppointmentDTO>(createdAppointment);
			return appointmentDTO;
		}

		public async Task<bool> DeleteAppointment(Guid id)
		{
			var isDeleted = await appointmentRepository.Delete(id);
			return isDeleted;
		}

		public async Task<PaginationList<AppointmentDTO>> GetAll(AppointmentSpeParam appointmentSpeParam)
		{
			var spec = new BaseSpecification<Appointment>(x =>
				(appointmentSpeParam.Statuses == null || (appointmentSpeParam.Statuses.Contains((Status)x.Status))) &&
				(appointmentSpeParam.FromDate == DateTime.MinValue || x.Date >= appointmentSpeParam.FromDate) &&
				(appointmentSpeParam.ToDate == DateTime.MaxValue || x.Date <= appointmentSpeParam.ToDate)
			);

			if (!appointmentSpeParam.IsDescending)
			{
				spec.AddOrderBy(x => x.Date);
			} else
			{
				spec.AddDescending(x => x.Date);
			}

			int skip = (appointmentSpeParam.pageIndex - 1) * appointmentSpeParam.pageSize;
			int take = appointmentSpeParam.pageSize;

			spec.ApplyPaging(take, skip);

			var appointmentDomain = await appointmentRepository.GetAll(spec);

			var result = mapper.Map<PaginationList<AppointmentDTO>>(appointmentDomain);

			return result;
		}

		public async Task<AppointmentDetailDTO> GetById(Guid id, bool isInclude)
		{
			Appointment? appointment;

			var spec = new BaseSpecification<Appointment>();
			if (isInclude)
			{
				spec.AddInclude(x => x.Patient);
				spec.AddInclude(x => x.Doctor);
			}

			if(isInclude)
			{
				appointment = await appointmentRepository.GetById(id, spec);
			} else
			{
				appointment = await appointmentRepository.GetById(id, spec);
			}
			var appoitmentDomain = await appointmentRepository.GetById(id, spec);
			var result = mapper.Map<AppointmentDetailDTO>(appoitmentDomain);
			return result;
		}

		public Task<AppointmentDetailDTO> UpdateAppointment(Guid id, UpdateAppointmentRequest updateAppointmentRequest)
		{
			throw new NotImplementedException();
		}
	}
}
