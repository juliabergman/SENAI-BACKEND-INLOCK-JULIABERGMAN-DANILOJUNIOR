using Senai.WebApi.InLock.Domains;
using Senai.WebApi.InLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string stringConexao = "Data Source=N-1S-DEV-17\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";


        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            var query = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var usuarioBuscado = new UsuarioDomain
                        {
                            ID = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}

