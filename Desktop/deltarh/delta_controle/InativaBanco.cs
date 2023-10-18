using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_controle
{
    internal class InativaBanco
    {
        StringConexao conecta = new StringConexao();

        public bool InativarEmpresa(mdlMissao missao, mdlPolitica politica, mdlEmpresa empresa)
        {
            string conexao = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();


                    string query = "UPDATE tbl_missaovisaovalores SET status = @status WHERE id_missaovisaovalores = @id_missaovisaovalores";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_missaovisaovalores", empresa.id_missao);
                    cmd.Parameters.AddWithValue("@status", missao.status);

                    int IdMissaoVisaoValores = cmd.ExecuteNonQuery();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "UPDATE tbl_politicadisciplinar SET status = @descricao WHERE id_politicadisciplinar = @id_politicadisciplinar";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_politicadisciplinar", empresa.id_politica);
                    cmd.Parameters.AddWithValue("@status", politica.status);

                    int IdPoliticaDisciplinar = cmd.ExecuteNonQuery();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"UPDATE tbl_empresa SET status = @status WHERE id_empresa = @id_empresa";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", empresa.id);
                    cmd.Parameters.AddWithValue("@status", empresa.status);


                    Int32 idInseriro = cmd.ExecuteNonQuery();
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
