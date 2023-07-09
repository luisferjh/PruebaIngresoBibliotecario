using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILibroRepository
    {
        Task AddLibroAsync(Libro libro);
        Task<Libro> GetLibroAsync(Guid isbn);
    }
}
