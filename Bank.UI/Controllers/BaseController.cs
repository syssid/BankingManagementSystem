using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Bank.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string? Token =>
         HttpContext.Session.GetString("Token");
        protected bool IsLoggedIn =>
            !string.IsNullOrEmpty(Token);

        protected void AttachToken(HttpClient client)
        {
            var token = HttpContext.Session.GetString("Token");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

}
