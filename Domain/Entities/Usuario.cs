using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public string IdentificacionUsuario { get; set; }
        public string Nombres { get; set; }
        public int TipoUsuario { get; set; }
    }
}
