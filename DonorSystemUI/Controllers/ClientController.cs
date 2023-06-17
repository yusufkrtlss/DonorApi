using DonorSystemUI.Dtos.BloodDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DonorSystemUI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("AddBloodRequest")]
        public IActionResult AddBloodRequest()
        {
            return View();
        }
        [HttpPost]
        [Route("AddBloodRequest")]
        public async Task<IActionResult> AddBloodRequest(RequestBloodDto request)
        {

            var client = _httpClientFactory.CreateClient();
            request.Requester = User.Identity.Name;
            // Serialize the request into a JSON object
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Send the request to the API
            var response = await client.PostAsync("http://localhost:5092/api/BloodRequest/AddBloodRequest", stringContent);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // The API successfully created the request, redirect the user to a success page
                return RedirectToAction("RequestSuccess");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                // If it's a bad request, read the error message from the API
                var error = await response.Content.ReadAsStringAsync();

                // Show the error to the user
                ModelState.AddModelError(string.Empty, $"Failed to create the request: {error}");
                return View(request);
            }
            //else
            //{
            //    // The API returned an error, show the error to the user
            //    ModelState.AddModelError(string.Empty, "Failed to create the request. Please try again later.");
            //    return View(request);
            //}
            return View();
        }
        
    }
}
