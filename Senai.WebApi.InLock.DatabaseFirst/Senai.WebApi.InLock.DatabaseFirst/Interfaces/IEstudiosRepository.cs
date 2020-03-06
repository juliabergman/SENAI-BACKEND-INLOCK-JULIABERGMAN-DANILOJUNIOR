using Senai.WebApi.InLock.DatabaseFirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Interfaces
{
    interface IEstudiosRepository
    {
        IEnumerable<Estudios> Listar();
        IEnumerable<Estudios> ListarComJogos();
        Estudios BuscarPorId(int id);
        void Cadastrar(Estudios novoEstudio);
        void Atualizar(Estudios estudioAtualizado);
        void Deletar(Estudios estudioEscolhido);
    }
}
