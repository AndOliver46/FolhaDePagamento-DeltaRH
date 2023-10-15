using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using delta_modelo;

namespace delta_controle
{
    public class ConsultaBanco
    {
        public string consulta = @"Data Source=NITRO-5;Initial Catalog=BD_DELTA;Integrated Security=True";

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

        public mdlEmpresa ConsultarEmpresaId(int id)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string query = "SELECT * FROM tbl_empresa WHERE id_empresa = @id_empresa";


                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", id);

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
            catch (Exception ex)
            {
                return null;
            }
        }

        public mdlColaborador ConsultarColab(string cpf)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE cpf = @cpf";


                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlColaborador colaborador = null;
                    while (rd.Read())
                    {
                        colaborador = new mdlColaborador();
                        colaborador.id = rd.GetInt32(0);
                        colaborador.nome = rd.GetString(1);
                        colaborador.nascimento = rd.GetDateTime(2);
                        colaborador.cpf = rd.GetString(3);
                        colaborador.contrato = rd.GetString(4);
                        colaborador.salario = rd.GetDecimal(5);
                        colaborador.senha = rd.GetString(6);
                        colaborador.cHoraria = rd.GetInt32(7);
                        colaborador.logradouro = rd.GetString(8);
                        colaborador.numero = rd.GetString(9);
                        colaborador.complemento = rd.GetString(10);
                        colaborador.bairro = rd.GetString(11);
                        colaborador.cep = rd.GetString(12);
                        colaborador.cidade = rd.GetString(13);
                        colaborador.uf = rd.GetString(14);
                        colaborador.fone1 = rd.GetString(15);
                        colaborador.fone2 = rd.GetString(16);
                        colaborador.email = rd.GetString(17);
                        colaborador.id_setor = rd.GetInt32(18);
                    }
                    rd.Close();

                    if (colaborador != null)
                    {
                        string query_s = "SELECT nome_setor FROM tbl_setor WHERE id_setor = @id_setor";

                        SqlCommand cmd_s = new SqlCommand(query_s, conexaodb);

                        cmd_s.Parameters.AddWithValue("@id_setor", colaborador.id_setor);

                        SqlDataReader rd_s = cmd_s.ExecuteReader();

                        mdlSetor setor = new mdlSetor();

                        while (rd_s.Read())
                        {
                            setor.nome = rd_s.GetString(0);
                        }
                        rd_s.Close();

                        colaborador.setor = setor;
                    }
                    return colaborador;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlSetor> ConsultarSetor(int idempresa)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_setor WHERE id_empresa = @id_empresa";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", idempresa);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlSetor> setores = new List<mdlSetor>();
                    while (rd.Read())
                    {
                       mdlSetor setor = new mdlSetor();
                        setor.id = rd.GetInt32(0);
                        setor.nome = rd.GetString(1);
                        setor.idEmpresa = rd.GetInt32(2);

                        setores.Add(setor);
                    }
                    rd.Close();

                    return setores;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlEmpresa> ListarEmpresas() 
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_empresa";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlEmpresa> empresas = new List<mdlEmpresa>();
                    while (rd.Read())
                    {
                        mdlEmpresa empresa = new mdlEmpresa();
                        empresa.id = rd.GetInt32(0);
                        empresa.razao = rd.GetString(2);

                        empresas.Add(empresa);
                    }
                    rd.Close();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlColaborador> ListarColaborador(int id_setor)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE id_setor = @id_setor";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_setor", id_setor);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlColaborador> colabs = new List<mdlColaborador>();
                    while (rd.Read())
                    {
                        mdlColaborador colab = new mdlColaborador();

                        colab.id = rd.GetInt32(0);
                        colab.nome = rd.GetString(1);

                        colabs.Add(colab);
                    }
                    rd.Close();

                    return colabs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public mdlSetor BuscarSetor(string id)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_setor WHERE id_empresa = @id_empresa";


                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", id);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlSetor setor = new mdlSetor(); ;
                    while (rd.Read())
                    {
                        
                        setor.id = rd.GetInt32(0);
                        setor.nome = rd.GetString(1);
                        setor.idEmpresa = rd.GetInt32(2);

                    }
                    rd.Close();

                    if (setor != null)
                    {
                        string query_s = "SELECT razao_social FROM tbl_empresa WHERE id_empresa = @id_empresa";

                        SqlCommand cmd_s = new SqlCommand(query_s, conexaodb);

                        cmd_s.Parameters.AddWithValue("@id_empresa", setor.idEmpresa);

                        SqlDataReader rd_s = cmd_s.ExecuteReader();

                        mdlEmpresa empresa = new mdlEmpresa();

                        while (rd_s.Read())
                        {
                            empresa.razao = rd_s.GetString(2);
                        }
                        rd_s.Close();

                        setor.empresa = empresa;
                    }
                    return setor;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void BuscarPendentes()
        {

            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                conexaodb.Open();

                var sqlQuery = "SELECT cnpj, razao_social, status FROM tbl_empresa WHERE status = 'Pendente'";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexaodb))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                    }
                }
            }
        }
    }
}
