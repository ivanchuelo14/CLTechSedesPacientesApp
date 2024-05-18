using CLTechSedesPacientesApp.Applicattion.Services;
using CLTechSedesPacientesApp.Infraestructure.Configuration;
using CLTechSedesPacientesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLTechSedesPacientesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISedeService _sedeService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, ISedeService sedeService, IConfiguration configuration)
        {
            _logger = logger;
            _sedeService = sedeService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {            
            int lab62SedeId = _configuration.GetValue<int>("KeyConfig:Lab62SedeId");
            var eu = _sedeService.GetAllSedesEnterprise(lab62SedeId);

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
