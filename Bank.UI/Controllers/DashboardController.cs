using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
