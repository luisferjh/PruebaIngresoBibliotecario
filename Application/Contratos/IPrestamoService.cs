using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contratos
{
    public interface IPrestamoService
    {
        Task<ResponseServiceDTO> InsertPrestamoAsync(CreatePrestamoDTO createPrestamoDTO);
        Task<Prestamo> GetPrestamoAsync(Guid idPrestamo);
    }
}
