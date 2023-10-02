using delta_modelo;
using System;
using System.Data.SqlClient;


namespace delta_controle
{
    public class CadColab
    {
        private string conexao = @"Data Source=desktop-dk36nf7\sqlexpress;Initial Catalog=BD_DELTA;Integrated Security=True";

        public bool CadastrarColab(mdlColaborador colab)
        {
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"
        INSERT INTO tbl_empresa (
            nome, 
            data_nascimento, 
            cpf, 
            tipo_contrato, 
            salario_bruto, 
            senha, 
            carga_horaria, 
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
            id_setor) 
         VALUES (
            @nome, 
            @data_nascimento, 
            @cpf, 
            @tipo_contrato, 
            @salario_bruto, 
            @senha, 
            @carga_horaria, 
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
            @id_setor);
        SELECT CAST(scope_identity() AS int)";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);


                    cmd.Parameters.AddWithValue("@nome", colab.nome);
                    cmd.Parameters.AddWithValue("@data_nascimento", colab.nascimento);
                    cmd.Parameters.AddWithValue("@cpf", colab.cpf);
                    cmd.Parameters.AddWithValue("@tipo_contrato", colab.contrato);
                    cmd.Parameters.AddWithValue("@salario_bruto", colab.salario);
                    cmd.Parameters.AddWithValue("@senha", colab.senha);
                    cmd.Parameters.AddWithValue("carga_horaria", colab.cHoraria);
                    cmd.Parameters.AddWithValue("@logradouro", colab.logradouro);
                    cmd.Parameters.AddWithValue("@numero", colab.numero);
                    cmd.Parameters.AddWithValue("@complemento", colab.complemento);
                    cmd.Parameters.AddWithValue("@bairro", colab.bairro);
                    cmd.Parameters.AddWithValue("@cep", colab.cep);
                    cmd.Parameters.AddWithValue("@cidade", colab.cidade);
                    cmd.Parameters.AddWithValue("@uf", colab.uf);
                    cmd.Parameters.AddWithValue("@telefone", colab.fone1);
                    cmd.Parameters.AddWithValue("@telefone2", colab.fone2);
                    cmd.Parameters.AddWithValue("@email", colab.email);
                    cmd.Parameters.AddWithValue("@id_setor", colab.id_setor);


                    int idInserido = (int)cmd.ExecuteScalar();
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
