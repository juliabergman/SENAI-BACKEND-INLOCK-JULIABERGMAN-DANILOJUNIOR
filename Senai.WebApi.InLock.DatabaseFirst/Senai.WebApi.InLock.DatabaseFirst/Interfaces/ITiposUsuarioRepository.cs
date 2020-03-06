using Senai.WebApi.InLock.DatabaseFirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Interfaces
{
    interface ITiposUsuarioRepository
    {
        IEnumerable<TiposUsuario> Listar();
        void Cadastrar(TiposUsuario novoTipoUsuario);
        void Atualizar(TiposUsuario tipoUsuarioAtualizado);
        void Deletar(TiposUsuario tipoUsuarioEscolhido);
        TiposUsuario BuscarPorId(int id);
    }
}
