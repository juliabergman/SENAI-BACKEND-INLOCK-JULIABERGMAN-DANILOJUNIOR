using Senai.WebApi.InLock.DatabaseFirst.Domain;
using Senai.WebApi.InLock.DatabaseFirst.Interfaces;
using Senai.WebApi.InLock.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Repositories
{
    public class EstudiosRepository : RepositoryBase, IEstudiosRepository
    {
        private IJogosRepository _jogosRepository { get; set; }

        public EstudiosRepository()
        {
            _jogosRepository = new JogosRepository();
        }

        public void Atualizar(Estudios novoEstudio)
        {
            dbo.Estudios.Update(novoEstudio);
            dbo.SaveChanges();
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            dbo.Estudios.Add(novoEstudio);
            dbo.SaveChanges();
        }

        public void Deletar(Estudios estudioEscolhido)
        {
            dbo.Estudios.Remove(estudioEscolhido);
            dbo.SaveChanges();
        }

        public IEnumerable<Estudios> Listar()
        {
            return dbo.Estudios;
        }

        public IEnumerable<Estudios> ListarComJogos()
        {
            var todosEstudios = Listar();
            var todosJogos = _jogosRepository.Listar();

            var estudiosPopulados = todosEstudios.Select(x => new Estudios
            {
                IdEstudio = x.IdEstudio,
                NomeEstudio = x.NomeEstudio,
                Jogos = todosJogos.Where(j => j.IdEstudio == x.IdEstudio).ToList()
            });

            return estudiosPopulados;
        }

        public Estudios BuscarPorId(int id)
        {
            return dbo.Estudios.FirstOrDefault(x => x.IdEstudio == id);
        }
    }
}
