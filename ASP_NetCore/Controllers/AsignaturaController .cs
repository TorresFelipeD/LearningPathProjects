using System;
using System.Linq;
using System.Collections.Generic;
using ASP_NetCore.Models;
using ASP_NetCore.Models.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index/{Id?}")]
        public IActionResult Index(string Id)
        {
            Random rdm = new Random();
            Asignatura asignatura = new Asignatura()
            {
                Nombre = "Matematicas"
            };

            var asignaturaObj = (from asig in _context.Asignaturas
                                 where asig.Id == Id
                                 select asig).SingleOrDefault();

            if (string.IsNullOrEmpty(Id))
            {
                return View("MultiAsignatura",_context.Asignaturas.ToList());
            }
            else
            {
                return View(asignaturaObj);
            }
        }
        public IActionResult MultiAsignatura()
        {
            var listAsignatura = new List<Asignatura>(){
                new Asignatura(){Nombre = "Programación"},
                new Asignatura(){Nombre = "Algebra"},
                new Asignatura(){Nombre = "Historia"},
                new Asignatura(){Nombre = "Ciencias"}
            };
            return View(_context.Asignaturas.ToList());
        }
        private readonly EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}