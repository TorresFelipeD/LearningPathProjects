using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP_NetCore.Models;

namespace ASP_NetCore.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required(ErrorMessage ="Campo Nombre requerido")]
        [StringLength(10, ErrorMessage = "Longitud máxima es de 10")]
        [MinLength(3, ErrorMessage = "Longitud minima de 3")]
        [Display(Name = "Nombre Curso", Prompt = "Ej: 401")]
        public override string Nombre { get; set; }
        public TiposJornada TipoJornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Address { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}