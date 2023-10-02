using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Configuration;
using delta_modelo;

namespace delta_controle
{
    public class Conexao
    {
        private string conexao = @"Data Source=desktop-dk36nf7\sqlexpress;Initial Catalog=BD_DELTA;Integrated Security=True";

        public bool CadastrarEmpresa(mdlMissao missao, mdlPolitica politica, mdlEmpresa empresa)
        {
            try
            {
                int IdMissaoVisaoValores;
                int IdPoliticaDisciplinar;

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
        INSERT INTO tbl_empresa (
            senha, 
            razao_social, 
            cnpj, 
            nome_responsavel, 
            cpf_responsavel, 
            logradouro, 
            numero, 
            complemento, 
            bairro, 
            cep, 
            cidade, 
            uf, 
            telefone, 
            telefone2, 
            email, 
            status,
            id_missaovisaovalores, 
            id_politicadisciplinar
        ) VALUES (
            @senha, 
            @razao_social, 
            @cnpj, 
            @nome_responsavel, 
            @cpf_responsavel, 
            @logradouro, 
            @numero, 
            @complemento, 
            @bairro, 
            @cep, 
            @cidade, 
            @uf, 
            @telefone, 
            @telefone2, 
            @email, 
            @status,
            @id_missaovisaovalores, 
            @id_politicadisciplinar
        );
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
                    cmd.Parameters.AddWithValue("@id_missaovisaovalores", IdMissaoVisaoValores);
                    cmd.Parameters.AddWithValue("@id_politicadisciplinar", IdPoliticaDisciplinar);

                    int idInserido = (int)cmd.ExecuteScalar();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
