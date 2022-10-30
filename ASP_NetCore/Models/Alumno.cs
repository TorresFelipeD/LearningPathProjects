using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_NetCore.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        [Required]
        [Display(Prompt = "Indique un nombre")]
        [MinLength(2)]
        public override string Nombre { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public Alumno()
        {
            Evaluaciones = new List<Evaluacion>();
        }
    }
}