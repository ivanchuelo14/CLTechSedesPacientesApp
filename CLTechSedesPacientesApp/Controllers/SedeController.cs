using CLTechSedesPacientesApp.Applicattion.Services;
using CLTechSedesPacientesApp.Domain;
using CLTechSedesPacientesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLTechSedesPacientesApp.Controllers
{
    public class SedeController : Controller
    {
        private readonly ISedeService _sedeService;

        public SedeController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }

        public IActionResult New()
        {
            SedeViewModel model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(SedeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var listSedes = new List<Lab63Sedes>();
                Lab63Sedes lab63Sede = new()
                {
                    Nombre = model.Nombre,
                    Codigo = model.Codigo,
                    FechaCreacion = DateTime.Now,
                    Latitud = model.Latitud,
                    Longitud = model.Longitud
                };
                listSedes.Add(lab63Sede);

                var result = _sedeService.GuardarSedes(listSedes);
                if (result)
                {
                    //TODO: Pendiente si toca agregar este demografico al LIS
                    TempData["AlertMessage"] = "Sede creada con éxito";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult Edit(int Id, int IdEnterprise)
        {
            var sede = _sedeService.GetSedeById(Id);
            if (sede != null)
            {
                SedeViewModel model = new()
                {
                    Nombre = sede.Nombre,
                    Codigo = sede.Codigo,
                    Latitud = sede.Latitud,
                    Longitud = sede.Longitud,
                    IdEnterprise = sede.IdEnterprise,
                    Id = Id
                };
                return View(model);
            }

            TempData["AlertMessageWarning"] = "Ocurrio un error al consultar la sede";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SedeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sede = _sedeService.GetSedeById(model.Id);
                if (sede != null)
                {
                    var listSedes = new List<Lab63Sedes>();
                    sede.Nombre = model.Nombre;
                    sede.Codigo = model.Codigo;
                    sede.Latitud = model.Latitud;
                    sede.Longitud = model.Longitud;
                    listSedes.Add(sede);
                    var result = _sedeService.GuardarSedes(listSedes);
                    if (result)
                    {
                        //TODO: Pendiente si toca agregar este demografico al LIS
                        TempData["AlertMessage"] = "Sede actualizada con éxito";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["AlertMessageWarning"] = "Ocurrio un error al consultar el estudiante";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}
