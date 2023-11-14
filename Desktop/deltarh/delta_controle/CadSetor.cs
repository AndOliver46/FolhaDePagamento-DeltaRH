using delta_modelo;
using System;
using System.Data.SqlClient;

namespace delta_controle
{
    public class CadSetor
    {
        StringConexao conecta = new StringConexao();

        public bool CadastrarSetor(mdlSetor setor)
        {
            string conexao = conecta.stringSql;
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
