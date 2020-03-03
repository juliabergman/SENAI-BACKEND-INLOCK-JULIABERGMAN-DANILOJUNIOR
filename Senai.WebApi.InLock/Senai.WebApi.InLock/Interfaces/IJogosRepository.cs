using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.InLock.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Interfaces
{

    interface IJogosRepository
    {
        //retornar a lista de jogos 
        List<JogoDomain> ListarJogos();
     
        //o administrador pode cadastrar novos usuários, jogos e estúdios 
        void Cadastrar(JogoDomain Jogo);
    }
}
