using Bank.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.DependencyInjection
{
    public static class ServiceContainer
    {

        public static IServiceCollection StartUpServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new ResponseCacheAttribute
                {
                    NoStore = true,
                    Location = ResponseCacheLocation.None
                });
            });

            services.AddHttpContextAccessor();
            services.AddSession(); // Make sure session is enabled

            services.AddTransient<AuthTokenHandler>();
            services.AddHttpClient("BankAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7100"); // Replace with your API base URL
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<AuthTokenHandler>();


            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication("Cookies")
                    .AddCookie("Cookies", options =>
                    {
                        options.LoginPath = "/Home/Index";
                        options.LogoutPath = "/Logout/Logout";
                        options.AccessDeniedPath = "/Home/Index";
                        options.AccessDeniedPath = "/Registration/RegistrationSuccess";
                    });

            services.AddAuthorization();


            return services;
        }
    }
}
