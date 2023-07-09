using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Prestamo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    
    }
}
