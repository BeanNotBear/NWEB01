using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.Services.PatientService;
using NWEB01.Domain.DTOs;
using NWEB01.Domain.Specifications;

namespace NWEB01.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PatientsController : ControllerBase
	{
		private readonly IPatientService patientService;

		public PatientsController(IPatientService patientService)
		{
			this.patientService = patientService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] PatientSpeParam patientSpeParam)
		{
			var result = await patientService.GetPatients(patientSpeParam);
			return Ok(result);
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] bool isIncludeAppoiment = false)
		{
			var result = await patientService.GetPatientById(id, isIncludeAppoiment);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddPatientRequest addPatientRequest)
		{
			var result = await patientService.AddPatient(addPatientRequest);
			if (result == null)
			{
				return BadRequest();
			}
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePatientRequest updatePatientRequest)
		{
			var result = await patientService.UpdatePatient(id, updatePatientRequest);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var isDeleted = await patientService.DeletePatient(id);
			if (isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
