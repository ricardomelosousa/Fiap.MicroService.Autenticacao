using Fiap.MicroService.Autenticacao.Application.Interfaces;
using Fiap.MicroService.Autenticacao.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.MicroService.Autenticacao.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }       

        public Usuario Login(string login, string senha)
        {
            return _usuarioRepository.Login(login, senha);
        }

        public Usuario Obter(int usuarioId)
        {
            return _usuarioRepository.Obter(usuarioId);
        }

        public int SalvarUsuario(Usuario usuario)
        {
            return _usuarioRepository.SalvarUsuario(usuario);
        }

        public string GenerateJwtToken(Usuario usuario)
        {
            try
            {
                var secret = _configuration["AppSettings:Secret"];
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()),
                                                 new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                                                 new Claim(ClaimTypes.Role, usuario.Role.ToString())}),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
