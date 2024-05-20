using CLTechSedesPacientesApp.Applicattion.Services;
using CLTechSedesPacientesApp.Domain;
using CLTechSedesPacientesApp.Infraestructure.Configuration;
using CLTechSedesPacientesApp.Infraestructure.Util;
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
        private readonly IValidationDictionary _validationDictionary;

        public HomeController(ILogger<HomeController> logger, ISedeService sedeService, IConfiguration configuration, IValidationDictionary validationDictionary)
        {
            _logger = logger;
            _sedeService = sedeService;
            _configuration = configuration;
            _validationDictionary = validationDictionary;
        }

        public IActionResult Index()
        {
            SedeFilterViewModel model = new();
            var sedesLis = _sedeService.GetSedesActivasEnterprise(_configuration.GetValue<int>("KeyConfig:Lab62SedeId"));
            //Controlar los errores en modelSatte
            if (ModelState.IsValid)
            {
                if (sedesLis != null && sedesLis.Count > 0)
                {
                    var getSedesNewTabla = _sedeService.ValidateSedesEnterpriseNewTbl(sedesLis);
                    model.SedesViewModel = getSedesNewTabla.Select(x => new SedeFilterDetail
                    {
                        CodigoCentral = x.Codigo,
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Latitud = string.IsNullOrEmpty(x.Latitud) ? "" : x.Latitud,
                        Longitud = string.IsNullOrEmpty(x.Longitud) ? "" : x.Longitud
                    }).ToList();
                }
                else
                {
                    var sedesCreate = _sedeService.GetAllSedes();
                    if (sedesCreate != null && sedesCreate.Count > 0)
                    {
                        model.SedesViewModel = sedesCreate.Select(x => new SedeFilterDetail
                        {
                            CodigoCentral = x.Codigo,
                            Id = x.Id,
                            Nombre = x.Nombre,
                            Latitud = string.IsNullOrEmpty(x.Latitud) ? "" : x.Latitud,
                            Longitud = string.IsNullOrEmpty(x.Longitud) ? "" : x.Longitud
                        }).ToList();

                    }
                }
            }
            return View(model);
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
