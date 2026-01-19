using Bank.UI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        [SessionAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
