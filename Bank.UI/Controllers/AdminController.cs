using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
