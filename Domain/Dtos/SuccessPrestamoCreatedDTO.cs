using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class SuccessPrestamoCreatedDTO
    {

        public Guid id { get; set; }
        public string fechaMaximaDevolucion { get; set; }
    }
}
