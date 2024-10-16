﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.CustomAttribute;
using NWEB01.Application.DTOs;
using NWEB01.Application.Services.DoctorService;
using NWEB01.Domain.Specifications;

namespace NWEB01.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{

		private readonly IDoctorService doctorService;

		public DoctorsController(IDoctorService doctorService)
		{
			this.doctorService = doctorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] DoctorSpeParam doctorSpeParam)
		{
			var doctors = await doctorService.GetDoctors(doctorSpeParam);
			return Ok(doctors);
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] bool isIncludeAppointment = false)
		{
			var doctor = await doctorService.GetDoctorById(id, isIncludeAppointment);
			if (doctor == null)
			{
				return NotFound();
			}
			return Ok(doctor);
		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> Create([FromBody] AddDoctorRequest addDoctorRequest)
		{
			var doctorDTO = await doctorService.AddDoctor(addDoctorRequest);
			if (doctorDTO == null)
			{
				return BadRequest();
			}
			return CreatedAtAction(nameof(GetById), new { id = doctorDTO.Id }, doctorDTO);
		}

		[HttpPut]
		[Route("{id:guid}")]
		[ValidateModel]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDoctorRequest updateDoctorRequest)
		{
			var doctorDTO = await doctorService.UpdateDoctor(id, updateDoctorRequest);
			if (doctorDTO == null)
			{
				return NotFound();
			}
			return Ok(doctorDTO);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var isDeleted = await doctorService.DeleteDoctor(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
