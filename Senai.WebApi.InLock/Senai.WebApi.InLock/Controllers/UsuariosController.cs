using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.WebApi.InLock.Domains;
using Senai.WebApi.InLock.Interfaces;
using Senai.WebApi.InLock.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }
        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            var usuarioBuscado = _usuariosRepository.BuscarPorEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound();
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.ID.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-pirulito-bombom"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.WebApi.InLock",         
                audience: "Senai.WebApi.InLock",            
                claims: claims,                   
                expires: DateTime.Now.AddMinutes(30),   
                signingCredentials: creds          
            );

            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
