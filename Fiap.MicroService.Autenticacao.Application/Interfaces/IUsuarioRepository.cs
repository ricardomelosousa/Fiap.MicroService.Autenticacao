using Fiap.MicroService.Autenticacao.Domain.Models;

namespace Fiap.MicroService.Autenticacao.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Obter(int usuarioId);
        Usuario Login(string login, string senha);
        int SalvarUsuario(Usuario usuario);
    }
}
