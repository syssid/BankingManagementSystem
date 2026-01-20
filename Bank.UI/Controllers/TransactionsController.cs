using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
