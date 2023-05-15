using itsm.parser.Model;
using ITSM_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace ITSM_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServerDBContext _dbContext = null;

        public HomeController(ILogger<HomeController> logger, ServerDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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

        public IActionResult Login() {
            return View();
        }

        public IActionResult OTRS_Dashboard() {
            ViewBag.Data = _dbContext.OTRS.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult OTRS_Dashboard(string fromDate,string toDate,string issueType,string status)
        {
            DateTime fromDateTime = DateTime.Parse(fromDate);
            

            ViewBag.Data = _dbContext.OTRS.Where(a => a.createdDate == fromDateTime).ToList();
            return View();
        }
    }
}