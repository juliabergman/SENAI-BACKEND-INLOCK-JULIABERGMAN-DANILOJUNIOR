using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.InLock.Domains;
using Senai.WebApi.InLock.Interfaces;
using Senai.WebApi.InLock.Repositories;

namespace Senai.WebApi.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }
        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }
        // GET api/values

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
 
        /// <returns>Um IEnumerable<JogoDomain></returns>
        /// 
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IEnumerable<JogoDomain> Listar()
        {
            return _jogosRepository.ListarJogos();
        }

        /// <summary>
        /// Cadastra um jogo
        /// </summary>

        /// <returns>Um HTTP Status Code pelo IActionResult</returns>
        /// 

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(JogoDomain Jogo)
        {
            try
            {
                _jogosRepository.Cadastrar(Jogo);
                return Ok("Ok");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/values/5       



    }
}
