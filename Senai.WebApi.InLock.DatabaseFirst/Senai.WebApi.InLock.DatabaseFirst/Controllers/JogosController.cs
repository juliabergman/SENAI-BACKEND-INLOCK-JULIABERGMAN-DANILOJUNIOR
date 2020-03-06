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
    public class JogosController : Controller
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        // GET: Jogos
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var listaJogos = _jogosRepository.Listar();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{nomeestudio}")]
        public IActionResult BuscarPorEstudio(string nomeEstudio)
        {
            try
            {
                var listaJogos = _jogosRepository.BuscarPorEstudio(nomeEstudio);
                return Ok(listaJogos);
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
                var jogoBuscado = _jogosRepository.BuscarPorId(id);
                return Ok(jogoBuscado);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogos novoUsuario)
        {
            try
            {
                _jogosRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Jogos jogoAtualizado)
        {
            try
            {
                _jogosRepository.Atualizar(jogoAtualizado);
                return Ok("Jogo atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var jogoEscolhido = _jogosRepository.BuscarPorId(id);

            if (jogoEscolhido == null)
            {
                return NotFound("Jogo não encontrado");
            }

            try
            {
                _jogosRepository.Deletar(jogoEscolhido);
                return Ok("Jogo deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}