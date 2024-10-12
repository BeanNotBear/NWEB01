using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.Services.AppointmentService;
using NWEB01.Domain.Specifications;

namespace NWEB01.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentsController : ControllerBase
	{
		private IAppointmentService appointmentsService;

		public AppointmentsController(IAppointmentService appointmentsService)
		{
			this.appointmentsService = appointmentsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] AppointmentSpeParam appointmentSpeParam)
		{
			var result = await appointmentsService.GetAll(appointmentSpeParam);
			return Ok(result);
		}
	}
}
