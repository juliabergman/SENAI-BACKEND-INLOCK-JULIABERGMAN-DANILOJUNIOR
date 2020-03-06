using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Interfaces;
using Senai.WebApi.InLock.DatabaseFirst.Repositories;

namespace Senai.WebApi.InLock.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]

    public class TiposUsuarioController : Controller
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }
        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var listaTiposUsuario = _tiposUsuarioRepository.Listar();
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
                var tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch
            {
                return NotFound();
            }
        }
        // GET: TiposUsuario/Details/5
        [HttpPost]
        public IActionResult Cadastrar(TiposUsuario novoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Atualizar(TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(tipoUsuarioAtualizado);
                return Ok("Tipo de usuário atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var tipoUsuarioEscolhido = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioEscolhido == null)
            {
                return NotFound("Tipo de usuário não encontrado");
            }

            try
            {
                _tiposUsuarioRepository.Deletar(tipoUsuarioEscolhido);
                return Ok("Tipo de usuário deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}