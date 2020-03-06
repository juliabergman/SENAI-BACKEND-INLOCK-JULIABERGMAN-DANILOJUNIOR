using Senai.WebApi.InLock.DatabaseFirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Interfaces
{
    interface IJogosRepository
    {
        IEnumerable<Jogos> Listar();
        IEnumerable<Jogos> uscarPorEstudio(string nomeEstudio);
        void Cadastrar(Jogos novoJogo);
        void Atualizar(Jogos jogoAtualizado);
        void Deletar(Jogos jogoEscolhido);
        Jogos BuscarPorId(int id);
    }
}
