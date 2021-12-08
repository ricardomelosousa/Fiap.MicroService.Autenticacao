using Fiap.MicroService.Autenticacao.Domain.Models;
using FluentValidation;

namespace Fiap.MicroService.Autenticacao.Api.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(a => a.Login).NotNull().WithMessage("Login deve ser informado");
            RuleFor(a => a.Senha).NotNull().WithMessage("Senha deve ser informada");
            RuleFor(a => a.Nome).NotNull().WithMessage("Nome deve ser informado.");
            RuleFor(a => a.Email).NotNull().WithMessage("Email deve ser informado");
        }
    }
}
