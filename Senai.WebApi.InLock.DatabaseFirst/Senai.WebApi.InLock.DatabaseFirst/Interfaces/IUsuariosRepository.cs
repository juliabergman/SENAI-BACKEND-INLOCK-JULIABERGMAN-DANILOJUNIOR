using Senai.WebApi.InLock.DatabaseFirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Interfaces
{
    interface IUsuariosRepository
    {
        IEnumerable<Usuarios> Listar();
        void Cadastrar(Usuarios novoUsuario);
        void Atualizar(Usuarios usuarioEscolhido);
        void Deletar(Usuarios usuarioEscolhido);
        Usuarios BuscarPorId(int id);
    }
}
