using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP_NetCore.Models.InMemory
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

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

            var cursos = CargarCursos(escuela);
            var asignaturas = CargarAsignaturas(cursos);
            var alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            List<Alumno> listAlumno = new List<Alumno>();
            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRnd = rnd.Next(5,10);
                var tmpList = GenerarAlumnos(curso, cantRnd);
                listAlumno.AddRange(tmpList);
            }
            return listAlumno;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listAsignatura = new List<Asignatura>();
            foreach (var curso in cursos)
            {

                var tmpList = new List<Asignatura>(){
                    new Asignatura() { CursoId = curso.Id,Nombre = "Programación" },
                    new Asignatura() { CursoId = curso.Id,Nombre = "Algebra" },
                    new Asignatura() { CursoId = curso.Id,Nombre = "Historia" },
                    new Asignatura() { CursoId = curso.Id,Nombre = "Ciencias" }
                };

                listAsignatura.AddRange(tmpList);
            }
            return listAsignatura;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                new Curso(){ EscuelaId = escuela.Id,Nombre = "101",TipoJornada = TiposJornada.Mañana, Address = "CLL 5" },
                new Curso(){ EscuelaId = escuela.Id,Nombre = "102",TipoJornada = TiposJornada.Tarde, Address = "CLL 7" },
                new Curso(){ EscuelaId = escuela.Id,Nombre = "103",TipoJornada = TiposJornada.Noche, Address = "CLL 45" },
                new Curso(){ EscuelaId = escuela.Id,Nombre = "104",TipoJornada = TiposJornada.Mañana, Address = "CLL 55" }
            };
        }

        private List<Alumno> GenerarAlumnos(Curso curso, int cantidad = 20)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno() { Nombre = $"{n1} {n2} {a1}", CursoId = curso.Id };

            return listaAlumnos.OrderBy((x) => x.Id).Take(cantidad).ToList();
        }

    }
}