using DonorSystemUI.Dtos.DonorDto;
using DonorSystemUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DonorSystemUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5177/api/Login/Login", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var roles = JsonConvert.DeserializeObject<List<string>>(await responseMessage.Content.ReadAsStringAsync());
                if (roles.Contains("Staff"))
                {
                    return RedirectToAction("GetDonorList", "Staff");
                }
                else if (roles.Contains("Client"))
                {
                    return RedirectToAction("Index", "Client");
                }
               // return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(CreateNewStaffDto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5177/api/Login/SignUp", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(model);
        }
    }
}
