using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LandingPage.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese un correo válido.")]
        public string Email { get; set; }

        public long Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]

        public int Edad { get; set; }
    }
}