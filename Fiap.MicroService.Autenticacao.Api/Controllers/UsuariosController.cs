
using Fiap.MicroService.Autenticacao.Api.Helpers;
using Fiap.MicroService.Autenticacao.Api.Model;
using Fiap.MicroService.Autenticacao.Api.Validator;
using Fiap.MicroService.Autenticacao.Application.Interfaces;
using Fiap.MicroService.Autenticacao.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.MicroService.Autenticacao.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var validator = new AuthenticateRequestValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);
            var user = _usuarioService.Login(model.Login, model.Senha);          
            if (user == null) return null;
            var token = _usuarioService.GenerateJwtToken(user);
            return Ok(new AuthenticateResponse(user, token));
        }

        [Authorize]
        [HttpGet("BuscarPorId")]
        public IActionResult GetbyId(int id)
        {
            var users = _usuarioService.Obter(id);
            return Ok(users);
        }

        [Authorize]
        [HttpPost("Criar")]
        public IActionResult Criar(Usuario usuario) 
        {
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var userId = _usuarioService.SalvarUsuario(usuario);
            return Ok($"Usuarioid {userId} criado com sucesso.");
        }
    }
}
