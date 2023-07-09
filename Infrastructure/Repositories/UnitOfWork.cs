using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersistenceContext _persistenceContext;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly ILibroRepository _libroRepository;

        public UnitOfWork(
            PersistenceContext persistenceContext,
            IUsuarioRepository usuarioRepository,
            IPrestamoRepository prestamoRepository,
            ILibroRepository libroRepository)
        {
            _persistenceContext = persistenceContext;
            _usuarioRepository = usuarioRepository;
            _prestamoRepository = prestamoRepository;
            _libroRepository = libroRepository;
        }

        public IUsuarioRepository UsuarioRepository { get => _usuarioRepository; }

        public IPrestamoRepository PrestamoRepository { get => _prestamoRepository; }

        public ILibroRepository LibroRepository { get => _libroRepository; }

        public int Save()
        {
            return _persistenceContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _persistenceContext.SaveChangesAsync();
        }
    }
}
