using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.DTOs;
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

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] bool isIncludeDetail)
		{
			var result = await appointmentsService.GetById(id, isIncludeDetail);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddAppointmentRequest addAppointmentRequest)
		{
			var result = await appointmentsService.AddAppointment(addAppointmentRequest);
			if (result == null)
			{
				return BadRequest();
			}
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid id,
			[FromBody] UpdateAppointmentRequest appointmentRequest)
		{
			var result = await appointmentsService.UpdateAppointment(id, appointmentRequest);
			if (result == null)
			{
				return BadRequest();
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var isDeleted = await appointmentsService.DeleteAppointment(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpGet]
		[Route("{doctorId:guid}/search")]
		public async Task<IActionResult> Search([FromRoute] Guid doctorId, [FromQuery] AppointmentSpeParam appointmentSpeParam)
		{
			var result = await appointmentsService.GetAppointmentsByDoctorId(doctorId, appointmentSpeParam);
			return Ok(result);
		}

		[HttpPatch]
		[Route("{id:guid}/cancel")]
		public async Task<IActionResult> Cancel([FromRoute] Guid id)
		{
			var result = await appointmentsService.CancelAppointment(id);
			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}
	}
}
