using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Interfaces;
using Senai.WebApi.InLock.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Repositories
{
    public class UsuariosRepository : RepositoryBase, IUsuariosRepository
    {
        public void Atualizar(Usuarios novoUsuario)
        {
            dbo.Usuarios.Update(novoUsuario);
            dbo.SaveChanges();
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            dbo.Usuarios.Add(novoUsuario);
            dbo.SaveChanges();
        }

        public void Deletar(Usuarios usuarioEscolhido)
        {
            dbo.Usuarios.Remove(usuarioEscolhido);
            dbo.SaveChanges();
        }

        public IEnumerable<Usuarios> Listar()
        {
            return dbo.Usuarios;
        }

        public Usuarios BuscarPorId(int id)
        {
            return dbo.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
        }
    }
}
