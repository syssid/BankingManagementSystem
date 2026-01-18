using Bank.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class DashboardController : BaseController
    {
        [SessionAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
