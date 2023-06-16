using DonorSystemUI.Dtos.BloodDto;
using Microsoft.AspNetCore.Mvc;

namespace DonorSystemUI.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBloodRequest(RequestBloodDto request)
        {
            return View();
        }
        
    }
}
