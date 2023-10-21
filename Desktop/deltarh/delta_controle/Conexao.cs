using System;
using System.Data.SqlClient;
using delta_modelo;

namespace delta_controle
{
    public class Conexao
    {
        StringConexao conecta = new StringConexao();

        public bool CadastrarEmpresa(mdlMissao missao, mdlPolitica politica, mdlEmpresa empresa, mdlSetor setor)
        {
            string conexao = conecta.stringSql;
            try
            {
                int IdMissaoVisaoValores;
                int IdPoliticaDisciplinar;
                int idInserido;

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();


                    string query = "INSERT INTO tbl_missaovisaovalores (descricao) VALUES (@descricao);SELECT CAST(scope_identity() AS int)";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@descricao", missao.descricao);

                    IdMissaoVisaoValores = (int)cmd.ExecuteScalar();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "INSERT INTO tbl_politicadisciplinar (descricao) VALUES (@descricao);SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@descricao", politica.descricao);

                    IdPoliticaDisciplinar = (int)cmd.ExecuteScalar();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"
        INSERT INTO tbl_empresa (senha, razao_social, cnpj, nome_responsavel, cpf_responsavel, logradouro, numero, complemento, bairro, 
        cep, cidade, uf, telefone, telefone2, email, status, vt, vr, ass_medica, odonto, gympass, id_missaovisaovalores, id_politicadisciplinar)
        VALUES (@senha, @razao_social, @cnpj, @nome_responsavel, @cpf_responsavel, @logradouro, @numero, @complemento, @bairro, 
        @cep, @cidade, @uf, @telefone, @telefone2, @email, @status, @vt, @vr, @ass_medica, @odonto, @gympass, @id_missaovisaovalores, @id_politicadisciplinar);
        SELECT CAST(scope_identity() AS int)";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@senha", empresa.senha);
                    cmd.Parameters.AddWithValue("@razao_social", empresa.razao);
                    cmd.Parameters.AddWithValue("@cnpj", empresa.cnpj);
                    cmd.Parameters.AddWithValue("@nome_responsavel", empresa.responsavel);
                    cmd.Parameters.AddWithValue("@cpf_responsavel", empresa.cpf);
                    cmd.Parameters.AddWithValue("@logradouro", empresa.logradouro);
                    cmd.Parameters.AddWithValue("@numero", empresa.numero);
                    cmd.Parameters.AddWithValue("@complemento", empresa.complemento);
                    cmd.Parameters.AddWithValue("@bairro", empresa.bairro);
                    cmd.Parameters.AddWithValue("@cep", empresa.cep);
                    cmd.Parameters.AddWithValue("@cidade", empresa.cidade);
                    cmd.Parameters.AddWithValue("@uf", empresa.uf);
                    cmd.Parameters.AddWithValue("@telefone", empresa.fone1);
                    cmd.Parameters.AddWithValue("@telefone2", empresa.fone2);
                    cmd.Parameters.AddWithValue("@email", empresa.email);
                    cmd.Parameters.AddWithValue("@status", empresa.status);
                    cmd.Parameters.AddWithValue("vt", empresa.vt);
                    cmd.Parameters.AddWithValue("vr", empresa.vr);
                    cmd.Parameters.AddWithValue("ass_medica", empresa.assMedica);
                    cmd.Parameters.AddWithValue("odonto", empresa.odonto);
                    cmd.Parameters.AddWithValue("gympass", empresa.gym);
                    cmd.Parameters.AddWithValue("@id_missaovisaovalores", IdMissaoVisaoValores);
                    cmd.Parameters.AddWithValue("@id_politicadisciplinar", IdPoliticaDisciplinar);

                    idInserido = (int)cmd.ExecuteScalar();
                }
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "INSERT INTO tbl_setor (nome_setor, id_empresa) VALUES (@nome_setor, @id_empresa);SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@nome_setor", setor.nome);
                    cmd.Parameters.AddWithValue("@id_empresa", idInserido);

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
