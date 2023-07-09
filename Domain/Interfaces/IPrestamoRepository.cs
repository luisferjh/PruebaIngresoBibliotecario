using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPrestamoRepository
    {
        Task AddPrestamoAsync(Prestamo prestamo);
        Task<Prestamo> GetPrestamoAsync(Guid id);
        Task<bool> UsuarioTienePrestamoAsync(string identificacion);
    }
}
