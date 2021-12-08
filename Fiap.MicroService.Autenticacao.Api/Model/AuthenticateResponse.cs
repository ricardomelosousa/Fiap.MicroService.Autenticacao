using Fiap.MicroService.Autenticacao.Domain.Models;

namespace Fiap.MicroService.Autenticacao.Api.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }     
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Usuario user, string token)
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Token = token;
            Nome = user.Nome;
        }
    }
}
