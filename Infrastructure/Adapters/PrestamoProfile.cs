using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Adapters
{
    public class PrestamoProfile : Profile
    {
        public PrestamoProfile()
        {
            CreateMap<CreatePrestamoDTO, Prestamo>();
        }
    }
}
