using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using TP3_EcoWatch.Models;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TP3_EcoWatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        



        // Un seul constructeur prenant à la fois ILogger<HomeController> et IWebHostEnvironment
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Analytics()
        {
            string jsonFilePath = Path.Combine(_env.ContentRootPath, "Data", "AirQuality.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            AirQuality[] airQualities = JsonConvert.DeserializeObject<AirQuality[]>(jsonContent);
            var airQualityList = airQualities.ToList(); // Convertir le tableau en liste
            return View(airQualityList);
        }
    

    public IActionResult Communities()
        {
            return View();
        }

        [Authorize(Roles = "user")]
        public IActionResult UserPage()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Search(string searchTerm)
        {
            var jsonFilePath = Path.Combine(_env.ContentRootPath, "Data", "AirQuality.json");
            var jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            var airQualities = JsonConvert.DeserializeObject<List<AirQuality>>(jsonContent);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                airQualities = airQualities.Where(aq => aq.Ville.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            return View("Analytics", airQualities);
        }



    }
}
