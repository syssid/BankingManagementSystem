using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
