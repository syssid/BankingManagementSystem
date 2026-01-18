using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public class LogoutController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Login", "Login");

            HttpContext.Session.Clear();

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return RedirectToAction("Login", "Login");
        }
    }
}