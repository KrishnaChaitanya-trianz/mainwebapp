using MainApp.Models;
using MainApp.bal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MainApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskBal _taskBal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, ITaskBal taskBal, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _taskBal = taskBal;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                 string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                _taskBal.InsertTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = _httpContextAccessor.HttpContext.TraceIdentifier });
        }
    }
}

