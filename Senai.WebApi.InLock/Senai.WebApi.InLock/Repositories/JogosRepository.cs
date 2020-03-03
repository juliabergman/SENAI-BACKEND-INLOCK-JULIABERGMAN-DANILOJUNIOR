using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.InLock.Domains;
using Senai.WebApi.InLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Repositories
{

    //aqui vai cadastrar as coisas 
    public class JogosRepository : IJogosRepository
    {

        private string stringConexao = "Data Source=N-1S-DEV-17\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";


        public List<JogoDomain> ListarJogos()
        {
            var listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                var query = "SELECT Jogos.NomeJogo, Estudios.NomeEstudio, Jogos.Valor, Jogos.Descricao, Jogos.DataLancamento FROM Jogos INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var jogo = new JogoDomain
                        {
                            Nome = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataDeLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToDouble(rdr["Valor"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };
                        listaJogos.Add(jogo);
                    }
                }
                return listaJogos;
            }
        }

        public void Cadastrar(JogoDomain jogo)
        {
            var query = "INSERT INTO Jogos (NomeJogo, Valor, Descricao, DataLancamento, IdEstudio) VALUES (@Nome, @Valor, @Descricao, @DataLancamento, @IdEstudio)";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataDeLancamento);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
