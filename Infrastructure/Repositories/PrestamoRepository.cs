using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public PrestamoRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task AddPrestamoAsync(Prestamo prestamo)
        {
            await _persistenceContext.Prestamos.AddAsync(prestamo);
        }

        public async Task<Prestamo> GetPrestamoAsync(Guid id)
        {
            return await _persistenceContext.Prestamos.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UsuarioTienePrestamoAsync(string identificacion)
        {
            return await _persistenceContext.Prestamos.AnyAsync(f => f.IdentificacionUsuario == identificacion);
        }
    }
}
