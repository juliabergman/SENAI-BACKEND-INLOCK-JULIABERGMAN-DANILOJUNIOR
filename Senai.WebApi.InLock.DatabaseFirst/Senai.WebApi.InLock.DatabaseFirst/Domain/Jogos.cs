using System;
using System.Collections.Generic;

namespace Senai.WebApi.InLock.DatabaseFirst.Domain
{
    public partial class Jogos
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal? Valor { get; set; }
        public int? IdEstudio { get; set; }

        public Estudios IdEstudioNavigation { get; set; }
    }
}
