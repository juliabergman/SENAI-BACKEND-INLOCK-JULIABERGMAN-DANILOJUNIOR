using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Repositories;

namespace Senai.WebApi.InLock.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        private UsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        public IActionResult Listar()
        {
            try
            {
                var listaUsuarios = _usuariosRepository.Listar();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuarioBuscado = _usuariosRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);
            }
            catch
            {
                return NotFound();
            }
        }
        // GET: Usuarios/Details/5
        [HttpPost]
        public IActionResult Cadastrar(Usuarios novoUsuario)
        {
            try
            {
                _usuariosRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Usuarios usuarioAtualizado)
        {
            try
            {
                _usuariosRepository.Atualizar(usuarioAtualizado);
                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var usuarioEscolhido = _usuariosRepository.BuscarPorId(id);

            if (usuarioEscolhido == null)
            {
                return NotFound("Usuário não encontrado");
            }

            try
            {
                _usuariosRepository.Deletar(usuarioEscolhido);
                return Ok("Usuário deletado com sucesso");
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}