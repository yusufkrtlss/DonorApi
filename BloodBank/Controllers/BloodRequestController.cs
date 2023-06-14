using BloodBank.DataAccess.Services;
using BloodBank.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private IBloodService _bloodService;

        public BloodRequestController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        [HttpPost]
        public IActionResult AddBloodRequest(RequestBlood request)
        {
            _bloodService.AddRequest(request);
            return Ok();
        }
    }
}
