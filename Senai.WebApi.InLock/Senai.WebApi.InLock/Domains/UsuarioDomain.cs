using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Domains
{
    // foi mudada pra só "UsuariosDOmain" pq no banco de dados não existe uma pasta com o nome cliente, administrador. E como tem itens que se repetem 
    // foi colocado em uma só mesmo
    //depois é só definir quem pode alterar oq no controllers
    public class UsuarioDomain
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email obrigatório!!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!!!!!! :(")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }
    }
}
