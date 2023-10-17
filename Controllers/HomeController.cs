using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VJAUDIO.Models;
using VJAUDIO.Services;

namespace VJAUDIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly MariaDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(MariaDbContext dbContext, IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var count = _dbContext.HeadsetColor.ToList().Select(x => x.Count).Sum();
            HttpContext.Session.SetInt32("Count", count);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cart()
        {
            var count = _dbContext.HeadsetColor.OrderBy(x => x.Id).ToList();
            return View(count);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddCount(string colorID)
        {
            if(!string.IsNullOrWhiteSpace(colorID))
            {
                var headsetcolor = _dbContext.HeadsetColor.FirstOrDefault(x => x.Color == colorID);
                if(headsetcolor != null)
                {
                    HeadsetColorService.Update(_dbContext, colorID);
                }
                else
                {
                    HeadsetColorService.Add(_dbContext, colorID);
                }
                var count = _dbContext.HeadsetColor.ToList().Select(x => x.Count).Sum();
                return Json(new { success = true, count = count });
            }
            return Json(new { success = false });
        }
    }
}