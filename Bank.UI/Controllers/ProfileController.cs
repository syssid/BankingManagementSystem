using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
