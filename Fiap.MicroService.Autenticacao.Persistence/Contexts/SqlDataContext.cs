using Fiap.MicroService.Autenticacao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fiap.MicroService.Autenticacao.Persistence.Contexts
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }      
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario()
            {
                Id = 1,
                Nome = "Administrador",
                Email = "admin@admin",
                Login = "admin",
                Senha = "123456",
                Role = "Administrador"
            });          
        }
     
    }
}
