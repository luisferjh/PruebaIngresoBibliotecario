using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class ResponseServiceDTO
    {
        public bool Result { get; set; }
        public object? Response { get; set; }
        public string Message { get; set; }
    }
}
