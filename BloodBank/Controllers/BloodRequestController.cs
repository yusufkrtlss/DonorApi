using BloodBank.DataAccess.Services;
using BloodBank.Models;
using BloodBank.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;

namespace BloodBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private IBloodService _bloodService;
        private readonly IHttpClientFactory _httpClientFactory;
        public BloodRequestController(IBloodService bloodService, IHttpClientFactory httpClientFactory)
        {
            _bloodService = bloodService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("AddBloodRequest")]
        public async Task<IActionResult> AddBloodRequest(RequestBlood request)
        {

            var client = _httpClientFactory.CreateClient();
           // var identityResponse = await client.GetAsync($"http://localhost:5177/api/Identity/GetUserName");
            //if (identityResponse.IsSuccessStatusCode)
            //{
            //    var identityJson = await identityResponse.Content.ReadAsStringAsync();
            //    var identity = JsonConvert.DeserializeObject<AppUser>(identityJson); // Replace Identity with the actual class of your identity model

            //    // Assign the requester username
            //    request.Requester = identity.UserName;
            //}
            //else if (identityResponse.StatusCode == HttpStatusCode.BadRequest)
            //{
            //    // If it's a bad request, read the error message from the API
            //    var error = await identityResponse.Content.ReadAsStringAsync();

            //    // Show the error to the user
            //    ModelState.AddModelError(string.Empty, $"Failed to create the request: {error}");
            //    return BadRequest(request);
            //}
            // Check the availability
            var responseMessage = await client.GetAsync($"http://localhost:5206/api/Donor/availability?city={request.City}&bloodType={request.BloodType}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var totalUnits = int.Parse(await responseMessage.Content.ReadAsStringAsync());
                if (totalUnits < request.Unit)
                {
                    return BadRequest("Not enough units available.");
                }
            }
            else
            {
                return BadRequest("Failed to check availability.");
            }

            // Add the request
           // var jsonData = JsonConvert.DeserializeObject<RequestBlood>(request);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //responseMessage = await client.PostAsync("http://localhost:5206/api/Donor/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                _bloodService.AddRequest(request);
                return Ok();
            }
            return Ok();
        }
    }
}
