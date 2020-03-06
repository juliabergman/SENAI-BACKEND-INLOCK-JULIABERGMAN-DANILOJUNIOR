using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Interfaces;
using Senai.WebApi.InLock.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Repositories
{
    public class JogosRepository : RepositoryBase, IJogosRepository
    {
        public void Atualizar(Jogos novoJogo)
        {
            dbo.Jogos.Update(novoJogo);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            dbo.Jogos.Add(novoJogo);
        }

        public void Deletar(Jogos jogoEscolhido)
        {
            dbo.Jogos.Remove(jogoEscolhido);
            dbo.SaveChanges();
        }

        public IEnumerable<Jogos> Listar()
        {
            return dbo.Jogos;
        }

        public IEnumerable<Jogos> BuscarPorEstudio(string nomeEstudio)
        {
            var estudio = dbo.Estudios.FirstOrDefault(x => x.NomeEstudio.Contains(nomeEstudio));
            return dbo.Jogos.Where(x => x.IdEstudio == estudio.IdEstudio);
        }

        public Jogos BuscarPorId(int id)
        {
            return dbo.Jogos.FirstOrDefault(x => x.IdJogo == id);
        }
    }
}
