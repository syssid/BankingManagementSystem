using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string? Token =>
         HttpContext.Session.GetString("Token");
        protected bool IsLoggedIn =>
            !string.IsNullOrEmpty(Token);
    }

}
