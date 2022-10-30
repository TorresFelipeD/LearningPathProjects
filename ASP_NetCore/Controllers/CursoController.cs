using Microsoft.AspNetCore.Mvc;
using ASP_NetCore.Models;
using System.Collections.Generic;
using System.Linq;
using ASP_NetCore.Models.InMemory;

namespace ASP_NetCore.Controllers
{
    public class CursoController : Controller
    {
        [Route("Curso/Index/{Id?}")]
        public IActionResult Index(string Id)
        {
            var CursoObj = (from cur in _context.Cursos
                            where cur.Id == Id
                            select cur).SingleOrDefault();

            if (string.IsNullOrEmpty(Id))
            {
                return View("MultiCurso", _context.Cursos.ToList());
            }
            else
            {
                return View(CursoObj);
            }
        }

        public IActionResult MultiCurso()
        {
            return View(_context.Cursos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                curso.EscuelaId = _context.Escuelas.FirstOrDefault().Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.Success = true;
                ViewBag.Message = "Curso creado correctamente";
                return View();
            }
            else {
                ViewBag.Success = false;
                return View(curso);
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad = 20)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno() { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((x) => x.Id).Take(cantidad).ToList();
        }

        private readonly EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}