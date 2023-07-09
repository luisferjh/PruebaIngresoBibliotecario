using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IPrestamoRepository PrestamoRepository { get; }
        ILibroRepository LibroRepository { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
