using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration Config;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
