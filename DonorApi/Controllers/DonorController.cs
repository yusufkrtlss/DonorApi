using DonorApi.DataAccess.Services;
using DonorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DonorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpPost]
        [Route("CreateDonor")]
        public async Task<IActionResult> CreateDonor(Donor createDonor)
        {
            if(ModelState.IsValid)
            {
                _donorService.CreateDonorAsync(createDonor);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }
        [HttpGet]
        [Route("UpdateDonor/{id}")]
        public async Task<IActionResult> UpdateDonor(int id)
        {
            var donor = await _donorService.GetDonorWithIdAsync(id);
            if(donor == null)
            {
                return NotFound();  
            }

            return Ok(donor);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDonor(Donor donor)
        {
            if(ModelState.IsValid)
            {
                var model = new Donor
                {
                    Fullname = donor.Fullname,
                    BloodType = donor.BloodType,
                    City = donor.City,
                    PhoneNo = donor.PhoneNo,
                    PhotoUrl = donor.PhotoUrl,
                    Town = donor.Town,
                };
                await _donorService.UpdateDonorAsync(model);
            }
            return Ok();
        }
        
        [HttpDelete]
        [Route("DeleteDonor")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var donor = _donorService.DeleteDonorAsync(id);
            return Ok();
        }
        [HttpPost]
        [Route("AddBloodtoBank")]
        public IActionResult AddBloodtoBank(AddBlood blood)
        {
            return Ok();
        }
    }
}
