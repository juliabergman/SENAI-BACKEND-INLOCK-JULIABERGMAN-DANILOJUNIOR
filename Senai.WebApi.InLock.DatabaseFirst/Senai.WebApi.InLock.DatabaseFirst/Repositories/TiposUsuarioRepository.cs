using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Interfaces;
using Senai.WebApi.InLock.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Repositories
{
    public class TiposUsuarioRepository : RepositoryBase, ITiposUsuarioRepository
    {
        public void Atualizar(TiposUsuario novoTipoUsuario)
        {
            dbo.TiposUsuario.Update(novoTipoUsuario);
            dbo.SaveChanges();
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            dbo.TiposUsuario.Add(novoTipoUsuario);
            dbo.SaveChanges();
        }

        public void Deletar(TiposUsuario tipoUsuarioEscolhido)
        {
            dbo.TiposUsuario.Remove(tipoUsuarioEscolhido);
            dbo.SaveChanges();
        }

        public IEnumerable<TiposUsuario> Listar()
        {
            return dbo.TiposUsuario;
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return dbo.TiposUsuario.FirstOrDefault(x => x.IdTipoUsuario == id);
        }
    }
}
