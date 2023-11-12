using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PhB.Web.Models;
using System.Diagnostics;
using System.Globalization;

namespace PhB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult ChangeCulture(string culture, string returnUrl)
        {
            // Validate the culture parameter to prevent security issues
            var supportedCultures = new[] { "en-us", "ar-eg", /* add more cultures */ };

            if (!supportedCultures.Contains(culture))
            {
                culture = "en-US"; // Default to English if an invalid culture is specified
            }

            CultureHelper.SetCulture(culture, culture);
            Response.Cookies.Append("Language", culture);
            
            

            // Redirect to the original page or a default page            
            return LocalRedirect(returnUrl ?? "/");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}