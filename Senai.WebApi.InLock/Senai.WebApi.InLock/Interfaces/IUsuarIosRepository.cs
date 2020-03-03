using Senai.WebApi.InLock.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Interfaces
{
    interface IUsuariosRepository
    {
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
