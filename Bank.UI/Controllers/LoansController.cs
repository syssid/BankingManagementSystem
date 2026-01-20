using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class LoansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
