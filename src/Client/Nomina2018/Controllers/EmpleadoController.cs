using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nomina2018.ViewModels;
using ServiceLayer;

namespace Nomina2018.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> logger;
        private readonly IEmpleadoService _empleadoService;
        private readonly IPuestoService _puestoService;
        private readonly IDepartamentoService _departamentoService;
        public EmpleadoController(ILogger<EmpleadoController> logger, IEmpleadoService empleadoService,IPuestoService puestoService,IDepartamentoService departamentoService)
        {

            this.logger = logger;
            _empleadoService = empleadoService;
            _puestoService = puestoService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<string> DataListUsers()
        {
            var data = await _empleadoService.GetEmpleados();
            var deptos = await _departamentoService.GetDepartamentos();
         
            return JsonConvert.SerializeObject(new { data,deptos });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var puestos = await _puestoService.GetPuestos();

            var model = new EmpleadoViewModel
            {
                
                Puestos = puestos.Select(x => new SelectListItem
                {
                    Value = x.PuestoId.ToString(),
                    Text = x.Nombre
                })
            };

            return PartialView("_Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _empleadoService.Create(model.empleado);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("No se actualizaron los datos");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int EmpleadoId)
        {
            var empleado = await _empleadoService.GetEmpleadoById(EmpleadoId);
            var puestos = await _puestoService.GetPuestos();

            var model = new EmpleadoViewModel
            {
                empleado = empleado,
                Puestos = puestos.Select(x => new SelectListItem
                {
                    Value = x.PuestoId.ToString(),
                    Text = x.Nombre
                })
        };

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmpleadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _empleadoService.Update(model.empleado);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("No se actualizaron los datos");
            }

            return View(model);
        }
    }
}
