using DonorApi.DataAccess.Context;
using DonorApi.DataAccess.Services;
using DonorApi.Models;
using DonorApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
                 _donorService.UpdateDonorAsync(model);
            }
            return Ok();
        }
        
        [HttpDelete]
        [Route("DeleteDonor/{id}")]
        public IActionResult DeleteDonor(int id)
        {
            _donorService.DeleteDonorAsync(id);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllDonors")]
        public async Task<IActionResult> GetDonorList()
        {
            return Ok(await _donorService.GetAllDonorsAsync());
        }
        [HttpGet]
        [Route("AddBloodtoBank/{id}")]
        public async Task<IActionResult> AddBloodtoBank(int id)
        {
            return Ok(await _donorService.GetDonorWithIdAsync(id));
        }
        [HttpPost]
        [Route("AddBloodtoBank")]
        public IActionResult AddBloodtoBank(AddBloodDto donor)
        {
            if (ModelState.IsValid)
            {
                var model = new Donor()
                {
                    BloodType = donor.BloodType,
                    City = donor.City,
                    Fullname = donor.Fullname,  
                    Town = donor.Town,
                    Unit = donor.Unit
                    
                };
                _donorService.UpdateDonorAsync(model);
            }
            return Ok();
        }


        [Produces("application/json")]
        [Route("search")]
        [HttpGet]
        public  IActionResult Search(string term)
        {
            try
            {
                var c = new DonorApiDb();
                term = term?.ToLower();
                //string term = HttpContext.Request.Query["term"].ToString().ToUpper();
                var query = c.Donors.ToList().Where(i => i.Fullname.Contains(term)).Select(x => new { id = x.Id, name = x.Fullname });
                return Ok(query);
            }
            catch (Exception ex)
            {
                // Log exception here
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("availability")]
        public IActionResult GetAvailability(string city, string bloodType)
        {
            var c = new DonorApiDb();
            var donors = c.Donors.Where(d => d.City == city && d.BloodType == bloodType);
            int totalUnits = donors.Sum(d => d.Unit);
            return Ok(totalUnits);
        }
    }
}
