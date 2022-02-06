using lab1_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab1_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator calc)
        {
            int fir_val = calc.value1;
            int sec_val = calc.value2;

            if (calc.calculate == "Сложить") { calc.result = fir_val + sec_val; }
            else if (calc.calculate == "Вычесть") { calc.result = fir_val - sec_val; }
            else if (calc.calculate == "Умножить") { calc.result = fir_val * sec_val; }
            else if (calc.calculate == "Поделить") { calc.result = fir_val / sec_val; }
            
            ViewData["result"] = calc.result;
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