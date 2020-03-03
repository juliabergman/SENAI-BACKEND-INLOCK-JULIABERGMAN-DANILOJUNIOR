using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Domains
{
    public class JogoDomain
    {
        public string Nome { get; set; }
        // double pra números quebrados :(
        public double Valor { get; set; }
        public string Descricao { get; set; }
        //int pri amigo não travar 
        public string DataDeLancamento { get; set; }
        public string IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
    }
}
