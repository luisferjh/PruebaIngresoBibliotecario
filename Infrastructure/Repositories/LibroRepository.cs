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
    public class LibroRepository : ILibroRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public LibroRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task AddLibroAsync(Libro libro)
        {
            await _persistenceContext.Libros.AddAsync(libro);
        }

        public async Task<Libro> GetLibroAsync(Guid isbn)
        {
            return await _persistenceContext.Libros.FirstOrDefaultAsync(f => f.Isbn == isbn);
        }
    }
}
