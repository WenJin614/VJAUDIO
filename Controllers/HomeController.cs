using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VJAUDIO.Models;

namespace VJAUDIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddCount(string colorID)
        {
            var getcount = HttpContext.Session.GetInt32("Count") ?? 0;
            var getcolor = HttpContext.Session.GetString("Color");
            var getbrowncount = HttpContext.Session.GetInt32("brown") ?? 0;
            var getgreencount = HttpContext.Session.GetInt32("green") ?? 0;
            var getbluecount = HttpContext.Session.GetInt32("blue") ?? 0;
            var getmauvecount = HttpContext.Session.GetInt32("mauve") ?? 0;
            var getorangecount = HttpContext.Session.GetInt32("orange") ?? 0;
            var getgreycount = HttpContext.Session.GetInt32("grey") ?? 0;
            var getblackcount = HttpContext.Session.GetInt32("black") ?? 0;
            var getwhitecount = HttpContext.Session.GetInt32("white") ?? 0;

            if (string.IsNullOrWhiteSpace(getcolor))
            {
                HttpContext.Session.SetString("Color", colorID);
            }
            else
            {
                if (!getcolor.Contains(colorID))
                {
                    HttpContext.Session.SetString("Color", getcolor + "," + colorID);
                }
            }

            if (colorID == "brown")
            {
                HttpContext.Session.SetInt32("brown", getbrowncount + 1);
            }
            else if (colorID == "green")
            {
                HttpContext.Session.SetInt32("green", getgreencount + 1);
            }
            else if (colorID == "blue")
            {
                HttpContext.Session.SetInt32("blue", getbluecount + 1);
            }
            else if (colorID == "mauve")
            {
                HttpContext.Session.SetInt32("mauve", getmauvecount + 1);
            }
            else if (colorID == "orange")
            {
                HttpContext.Session.SetInt32("orange", getorangecount + 1);
            }
            else if (colorID == "grey")
            {
                HttpContext.Session.SetInt32("grey", getgreycount + 1);
            }
            else if (colorID == "black")
            {
                HttpContext.Session.SetInt32("black", getblackcount + 1);
            }
            else if (colorID == "white")
            {
                HttpContext.Session.SetInt32("white", getwhitecount + 1);
            }

            HttpContext.Session.SetInt32("Count", getcount + 1);
            return Json(new { success = true, count = getcount + 1 });
        }
    }
}