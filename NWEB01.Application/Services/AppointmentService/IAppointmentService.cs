using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.AppointmentService
{
	public interface IAppointmentService
	{
		public Task<PaginationList<AppointmentDTO>> GetAll(AppointmentSpeParam appointmentSpeParam);
		public Task<AppointmentDetailDTO> GetById(Guid id, bool isInclude);
		public Task<AppointmentDTO> AddAppointment(AddAppointmentRequest addAppointmentRequest);
		public Task<AppointmentDetailDTO> UpdateAppointment(Guid id, UpdateAppointmentRequest updateAppointmentRequest);
		public Task<bool> DeleteAppointment(Guid id);
    }
}
