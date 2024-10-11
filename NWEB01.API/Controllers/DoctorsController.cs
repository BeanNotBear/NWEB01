using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.Services.UserService;
using NWEB01.Domain.Specifications.DoctorSpecification;

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
	}
}
