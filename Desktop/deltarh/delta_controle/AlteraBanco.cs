using delta_modelo;
using System;
using System.Data.SqlClient;

namespace delta_controle
{
    public class AlteraBanco
    {
        StringConexao conecta = new StringConexao();

        public bool AlterarEmpresa(mdlMissao missao, mdlPolitica politica, mdlEmpresa empresa)
        {
            string conexao = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();


                    string query = "UPDATE tbl_missaovisaovalores SET descricao = @descricao WHERE id_missaovisaovalores = @id_missaovisaovalores";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_missaovisaovalores", empresa.id_missao);
                    cmd.Parameters.AddWithValue("@descricao", missao.descricao);

                   int mvv = cmd.ExecuteNonQuery();

                    if (mvv > 0)
                    {
                        return true;
                    }

                }

                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "UPDATE tbl_politicadisciplinar SET descricao = @descricao WHERE id_politicadisciplinar = @id_politicadisciplinar";

                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    cmd.Parameters.AddWithValue("@id_politicadisciplinar", empresa.id_politica);
                    cmd.Parameters.AddWithValue("@descricao", politica.descricao);

                    int pd = cmd.ExecuteNonQuery();

                    if (pd > 0)
                    {
                        return true;
                    }
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
            vt = @vt, 
            vr = @vr, 
            ass_medica = @ass_medica, 
            odonto = @odonto, 
            gympass = @gympass

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
                    cmd.Parameters.AddWithValue("vt", empresa.vt);
                    cmd.Parameters.AddWithValue("vr", empresa.vr);
                    cmd.Parameters.AddWithValue("ass_medica", empresa.assMedica);
                    cmd.Parameters.AddWithValue("odonto", empresa.odonto);
                    cmd.Parameters.AddWithValue("gympass", empresa.gym);

                    Int32 idInseriro = cmd.ExecuteNonQuery();

                    if (idInseriro > 0)
                    {
                        return true;
                    }
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
            string conexao = conecta.stringSql;
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

        public bool AlterarColaborador(mdlColaborador colab)
        {
            string conexao = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = @"
        UPDATE tbl_colaborador SET
            nome = @nome,
            data_nascimento = @data_nascimento, 
            cpf = @cpf, 
            tipo_contrato = @tipo_contrato, 
            salario_bruto = @salario_bruto, 
            senha = @senha, 
            carga_horaria = @carga_horaria, 
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
            id_setor = @id_setor,
            cargo = @cargo,
            status = @status,
            id_empresa = @id_empresa,
            horas_banco = @horas_banco
            WHERE id_colaborador = @id_colaborador";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@id_colaborador", colab.id);
                    cmd.Parameters.AddWithValue("@nome", colab.nome);
                    cmd.Parameters.AddWithValue("@data_nascimento", Convert.ToDateTime(colab.nascimento));
                    cmd.Parameters.AddWithValue("@cpf", colab.cpf);
                    cmd.Parameters.AddWithValue("@tipo_contrato", colab.contrato);
                    cmd.Parameters.AddWithValue("@salario_bruto", colab.salario);
                    cmd.Parameters.AddWithValue("@senha", colab.senha);
                    int carga = Convert.ToInt32(colab.cHoraria);
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
                    cmd.Parameters.AddWithValue("@id_setor", colab.id_setor);
                    cmd.Parameters.AddWithValue("@cargo", colab.cargo);
                    cmd.Parameters.AddWithValue("@status", colab.status);
                    cmd.Parameters.AddWithValue("@id_empresa", colab.idEmpresa);
                    cmd.Parameters.AddWithValue("@horas_banco", colab.horas_banco);

                    Int32 idInseriro = cmd.ExecuteNonQuery();

                    if (idInseriro > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }

        public bool AlterarStatus(mdlEmpresa empresa)
        {
                string conexao = conecta.stringSql;
                try
                {
                    using (SqlConnection conexaodb = new SqlConnection(conexao))
                    {
                        conexaodb.Open();

                        string query = @"UPDATE tbl_empresa SET status = @status WHERE cnpj = @cnpj";

                        SqlCommand cmd = new SqlCommand(query, conexaodb);

                        cmd.Parameters.AddWithValue("@cnpj", empresa.cnpj);
                        cmd.Parameters.AddWithValue("@status", empresa.status);

                        Int32 idInseriro = cmd.ExecuteNonQuery();

                        if (idInseriro > 0)
                        {
                            return true;
                        }
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
