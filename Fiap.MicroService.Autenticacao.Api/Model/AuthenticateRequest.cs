using System.ComponentModel.DataAnnotations;

namespace Fiap.MicroService.Autenticacao.Api.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
