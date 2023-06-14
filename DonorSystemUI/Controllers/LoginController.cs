using Microsoft.AspNetCore.Mvc;

namespace DonorSystemUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
