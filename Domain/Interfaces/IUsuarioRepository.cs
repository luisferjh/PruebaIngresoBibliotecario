using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task<Usuario> GetUsuarioAsync(string identificacion);
    }
}
