using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Libro
    {
        [Key]
        public Guid Isbn { get; set; }
        public string Titulo { get; set; }
    }
}
