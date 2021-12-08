using Fiap.MicroService.Autenticacao.Application.Interfaces;
using Fiap.MicroService.Autenticacao.Domain.Models;
using Fiap.MicroService.Autenticacao.Persistence.Contexts;
using System;

namespace Fiap.MicroService.Autenticacao.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlDataContext _dataContext;

        public UsuarioRepository(SqlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Usuario Login(string login, string senha)
        {
            //use mock
            if (login == "admin@admin" && senha == "admin") 
            {
                return new Usuario() { Email = "admin@admin", Login = "admin@admin", Nome = "Administrador", Role = "Adm", Id = 1 };
            }
            return null;
            //return _dataContext.Usuarios.FirstOrDefault(s => s.Login == login && s.Senha == senha);

        }

        public Usuario Obter(int usuarioId)
        {
            return _dataContext.Usuarios.Find(usuarioId);

        }

        public int SalvarUsuario(Usuario usuario)
        {
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();
            return usuario.Id;
        }
    }
}
