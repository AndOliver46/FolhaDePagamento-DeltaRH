using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_controle
{
    public class AlteraBanco
    {
        private string conexao = @"Data Source=desktop-dk36nf7\sqlexpress;Initial Catalog=BD_DELTA;Integrated Security=True";

        public bool AlterarEmpresa(mdlMissao missao, mdlPolitica politica, mdlEmpresa empresa)
        {
            try
            {
                int IdMissaoVisaoValores;
                int IdPoliticaDisciplinar;

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();


                    string query = "UPDATE tbl_missaovisaovalores SET descricao = @descricao WHERE id_missaovisaovalores = @id_missaovisaovalores";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_missao", empresa.id_missao);
                    cmd.Parameters.AddWithValue("@descricao", missao.descricao);

                    IdMissaoVisaoValores = cmd.ExecuteNonQuery();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "UPDATE tbl_politicadisciplinar SET descricao = @descricao WHERE id_politicadisciplinar = @id_politicadisciplinar";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_politica", empresa.id_politica);
                    cmd.Parameters.AddWithValue("@descricao", politica.descricao);

                    IdPoliticaDisciplinar = cmd.ExecuteNonQuery();

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"
        UPDATE tbl_empresa SET
            senha = @senha, 
            razao_social = @razao_social, 
            cnpj = @cnpj, 
            nome_responsavel = @nome_responsavel, 
            cpf_responsavel = @cpf_responsavel, 
            logradouro = @logradouro, 
            numero = @numero, 
            complemento = @complemento, 
            bairro = @bairro, 
            cep = @cep, 
            cidade = @cidade, 
            uf = @uf, 
            telefone = @telefone, 
            telefone2 = @telefone2, 
            email = @email, 
            status = @status,
            id_missaovisaovalores = @id_missaovisaovalores, 
            id_politicadisciplinar = @id_politicadisciplinar
            WHERE id_empresa = @id_empresa";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", empresa.id);
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

                    Int32 idInseriro = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool AlterarSetor(mdlSetor setor)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "UPDATE tbl_setor SET nome_setor = @nome_setor WHERE id_setor = @id_setor";
                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@nome_setor", setor.nome);
                    cmd.Parameters.AddWithValue("@id_setor", setor.id);

                    Int32 recordsAffected = cmd.ExecuteNonQuery(); 

                    if(recordsAffected > 0) 
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
