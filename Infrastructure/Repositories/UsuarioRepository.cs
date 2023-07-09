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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public UsuarioRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _persistenceContext.Usuarios.AddAsync(usuario);
        }

        public async Task<Usuario> GetUsuarioAsync(string identificacion)
        {
            return await _persistenceContext.Usuarios.FirstOrDefaultAsync(f => f.IdentificacionUsuario == identificacion);
        }
    }
}
