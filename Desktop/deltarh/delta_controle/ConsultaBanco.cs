using System;
using System.Data.SqlClient;
using delta_modelo;

namespace delta_controle
{
    public class ConsultaBanco
    {
        public string consulta = @"Data Source=desktop-dk36nf7\sqlexpress;Initial Catalog=BD_DELTA;Integrated Security=True";

        public mdlEmpresa ConsultarEmpresa(string cnpj)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string query = "SELECT * FROM tbl_empresa WHERE cnpj = @cnpj";


                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@cnpj", cnpj);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlEmpresa empresa = null;
                    while (rd.Read())
                    {
                        empresa = new mdlEmpresa();
                        empresa.id = rd.GetInt32(0);
                        empresa.senha = rd.GetString(1);
                        empresa.razao = rd.GetString(2);
                        empresa.cnpj = rd.GetString(3);
                        empresa.responsavel = rd.GetString(4);
                        empresa.cpf = rd.GetString(5);
                        empresa.logradouro = rd.GetString(6);
                        empresa.numero = rd.GetString(7);
                        empresa.complemento = rd.GetString(8);
                        empresa.bairro = rd.GetString(9);
                        empresa.cep = rd.GetString(10);
                        empresa.cidade = rd.GetString(11);
                        empresa.uf = rd.GetString(12);
                        empresa.fone1 = rd.GetString(13);
                        empresa.fone2 = rd.GetString(14);
                        empresa.email = rd.GetString(15);
                        empresa.status = rd.GetString(16);
                        empresa.id_missao = rd.GetInt32(17);
                        empresa.id_politica = rd.GetInt32(18);
                    }
                    rd.Close();

                    if (empresa != null)
                    {
                        string query_m = "SELECT descricao FROM tbl_missaovisaovalores WHERE id_missaovisaovalores = @id_missao";

                        SqlCommand cmd_m = new SqlCommand(query_m, conexaodb);

                        cmd_m.Parameters.AddWithValue("@id_missao", empresa.id_missao);

                        SqlDataReader rd_m = cmd_m.ExecuteReader();

                        mdlMissao missao = new mdlMissao();

                        while (rd_m.Read())
                        {
                            missao.descricao = rd_m.GetString(0);
                        }
                        rd_m.Close();

                        string query_p = "SELECT descricao FROM tbl_politicadisciplinar WHERE id_politicadisciplinar = @id_politica";

                        SqlCommand cmd_p = new SqlCommand(query_p, conexaodb);

                        cmd_p.Parameters.AddWithValue("@id_politica", empresa.id_politica);

                        SqlDataReader rd_p = cmd_p.ExecuteReader();

                        mdlPolitica politica = new mdlPolitica();

                        while (rd_p.Read())
                        {
                            politica.descricao = rd_p.GetString(0);
                        }
                        rd_p.Close();
                        empresa.missao = missao;
                        empresa.politica = politica;
                    }

                    return empresa;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
    }
}
