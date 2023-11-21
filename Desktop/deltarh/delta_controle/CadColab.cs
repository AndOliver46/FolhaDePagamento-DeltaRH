using delta_modelo;
using System;
using System.Data.SqlClient;


namespace delta_controle
{
    public class CadColab
    {
        StringConexao conecta = new StringConexao();
        public bool CadastrarColab(mdlColaborador colab)
        {
            string conexao = conecta.stringSql;
            try
            {
                int idSetor, carga;

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"
        INSERT INTO tbl_colaborador (
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
            id_setor,
            cargo,
            status,
            id_empresa,
            horas_banco,
            data_admissao) 
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
            @id_setor,
            @cargo,
            @status,
            @id_empresa,
            @horas_banco,
            @data_admissao);
        SELECT CAST(scope_identity() AS int)";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);


                    cmd.Parameters.AddWithValue("@nome", colab.nome);
                    cmd.Parameters.AddWithValue("@data_nascimento", Convert.ToDateTime(colab.nascimento));
                    cmd.Parameters.AddWithValue("@cpf", colab.cpf);
                    cmd.Parameters.AddWithValue("@tipo_contrato", colab.contrato);
                    cmd.Parameters.AddWithValue("@salario_bruto", colab.salario);
                    cmd.Parameters.AddWithValue("@senha", colab.senha);
                    carga = Convert.ToInt32(colab.cHoraria);
                    cmd.Parameters.AddWithValue("carga_horaria", carga);
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
                    idSetor = Convert.ToInt32(colab.id_setor);
                    cmd.Parameters.AddWithValue("@id_setor", idSetor);
                    cmd.Parameters.AddWithValue("@cargo", colab.cargo);
                    cmd.Parameters.AddWithValue("@status", colab.status);
                    cmd.Parameters.AddWithValue("@id_empresa", colab.idEmpresa);
                    cmd.Parameters.AddWithValue("@horas_banco", colab.horas_banco);
                    cmd.Parameters.AddWithValue("@data_admissao", Convert.ToDateTime(colab.data_admissao));

                    int idInserido = (int)cmd.ExecuteScalar();
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
