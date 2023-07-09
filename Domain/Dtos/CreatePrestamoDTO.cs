using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class CreatePrestamoDTO
    {
        [Required]        
        public Guid Isbn { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "La identificación del usuario debe tener 8 caracteres.")]
        public string IdentificacionUsuario { get; set; }

        [Required]
        [EnumDataType(typeof(TipoUsuario), ErrorMessage = "El tipo de usuario seleccionado no es válido.")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
