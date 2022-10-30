using System;
using System.Linq;
using ASP_NetCore.Models;
using ASP_NetCore.Models.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NetCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            Random rdm = new Random();
            Escuela escuela = new Escuela(
                NombreEscuela: "Diego's School",
                AñoGraduacion: DateTime.Now.AddYears(-rdm.Next(5)).Year,
                Pais: "Colombia",
                Ciudad: "Bogota"
            );
            escuela.Nombre = "Academia de Aprendizaje Online";
            escuela.Address = "Av Cll 55 # 84 - 66";
            escuela.TipoEscuela = TiposEscuela.PreEscolar;

            var escuela_ = _context.Escuelas.FirstOrDefault();

            return View(escuela_);
        }
        private readonly EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}