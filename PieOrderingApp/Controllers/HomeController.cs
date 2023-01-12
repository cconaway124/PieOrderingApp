using Microsoft.AspNetCore.Mvc;
using PieOrderingApp.Models;
using PieOrderingApp.ViewModel;
using System.Diagnostics;

namespace PieOrderingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPieRepository _pieRepository;

        public HomeController(ILogger<HomeController> logger, IPieRepository pieRepository)
        {
            _logger = logger;
            _pieRepository = pieRepository;
        }

        public IActionResult Index([FromForm]OrderViewModel orderVM)
        {
            // for example purposes, no orders taken on weekends, and they need to order at least three days
            // in advance
            DateTime nextOrderableDate = DateTime.Today.AddDays(3);
            while (nextOrderableDate.DayOfWeek == DayOfWeek.Sunday || nextOrderableDate.DayOfWeek == DayOfWeek.Saturday)
            {
                nextOrderableDate = nextOrderableDate.AddDays(1); // add a day till it is not the weekend, this is the min date
            }

            orderVM.MinOrderableDate = nextOrderableDate.ToString("yyyy-MM-dd");

            orderVM.Pies = _pieRepository.GetAll();
            return View(orderVM);
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