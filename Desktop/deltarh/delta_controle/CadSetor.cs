using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_controle
{
    public class CadSetor
    {
        private string conexao = @"Data Source=NITRO-5;Initial Catalog=BD_DELTA;Integrated Security=True";

        public bool CadastrarSetor(mdlSetor setor)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "INSERT INTO tbl_setor (nome_setor, id_empresa) VALUES (@nome_setor, @id_empresa);SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@nome_setor", setor.nome);
                    cmd.Parameters.AddWithValue("@id_empresa", setor.idEmpresa);

                    int IdSetor = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
