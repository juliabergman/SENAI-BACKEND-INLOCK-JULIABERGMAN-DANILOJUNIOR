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
    public class EstudiosController : Controller
    {
        private IEstudiosRepository _estudiosRepository {get; set;}

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        public IActionResult Listar()
        {
            try
            {
                var listaEstudios = _estudiosRepository.Listar();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IEnumerable<Estudios> ListarComJogos()
        {

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var tipoUsuarioBuscado = _estudiosRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch
            {
                return NotFound();
            }
        }
        // GET: Estudios/Details/5
        [HttpPost]
        public IActionResult Cadastrar(Estudios novoUsuario)
        {
            try
            {
                _estudiosRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Estudios tipoUsuarioAtualizado)
        {
            try
            {
                _estudiosRepository.Atualizar(tipoUsuarioAtualizado);
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
            var tipoUsuarioEscolhido = _estudiosRepository.BuscarPorId(id);

            if (tipoUsuarioEscolhido == null)
            {
                return NotFound("Usuário não encontrado");
            }

            try
            {
                _estudiosRepository.Deletar(tipoUsuarioEscolhido);
                return Ok("Usuário deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}