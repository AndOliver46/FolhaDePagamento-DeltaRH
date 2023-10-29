using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_controle
{
    public class CadFolha
    {
        StringConexao conecta = new StringConexao();

        public bool CadastrarFolha(mdlFolhaDePagamento folha_recebida)
        {
            string conexao = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "INSERT INTO tbl_folhadepagamento " +
                        "(doc_folhadepagamento, valor_folhafinal, valor_desc_total, horas_trab, salario_liq, periodo_inicio, periodo_fim, status_folha, id_empresa, mes_referencia) VALUES " +
                        "(@doc_folhadepagamento, @valor_folhafinal, @valor_desc_total, @horas_trab, @salario_liq, @periodo_inicio, @periodo_fim, @status_folha, @id_empresa, @mes_referencia)";
                    SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                    if (folha_recebida.relatorio == null)
                    {
                        cmd.Parameters.Add("@doc_folhadepagamento", SqlDbType.VarBinary).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@doc_folhadepagamento", SqlDbType.VarBinary).Value = folha_recebida.relatorio;
                    }
                    cmd.Parameters.AddWithValue("@valor_folhafinal", folha_recebida.valor_final);
                    cmd.Parameters.AddWithValue("@valor_desc_total", folha_recebida.valor_desconto);
                    cmd.Parameters.AddWithValue("@horas_trab", folha_recebida.horas_trabalhadas);
                    cmd.Parameters.AddWithValue("@salario_liq", folha_recebida.salario_liquido);
                    cmd.Parameters.AddWithValue("@periodo_inicio", folha_recebida.periodo_inicio);
                    cmd.Parameters.AddWithValue("@periodo_fim", folha_recebida.periodo_fim);
                    cmd.Parameters.AddWithValue("@status_folha", folha_recebida.status_folha);
                    cmd.Parameters.AddWithValue("@id_empresa", folha_recebida.id_empresa);
                    cmd.Parameters.AddWithValue("@mes_referencia", folha_recebida.mes_referencia);

                    // Execute o comando SQL para inserir os dados no banco de dados
                    int inserido = cmd.ExecuteNonQuery();

                    if (inserido > 0)
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

        public bool UpdateFolha(mdlFolhaDePagamento folha_recebida)
        {
            string conexao = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(conexao))
                {
                    conexaodb.Open();

                    string query = "UPDATE tbl_folhadepagamento " +
                        "SET doc_folhadepagamento = @doc_folhadepagamento, " +
                        "valor_folhafinal = @valor_folhafinal, " +
                        "valor_desc_total = @valor_desc_total, " +
                        "horas_trab = @horas_trab, " +
                        "salario_liq = @salario_liq, " +
                        "periodo_inicio = @periodo_inicio, " +
                        "periodo_fim = @periodo_fim, " +
                        "status_folha = @status_folha, " +
                        "id_empresa = @id_empresa, " +
                        "mes_referencia = @mes_referencia " +
                        "WHERE id_folhadepagamento = @id_folhadepagamento";

                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    if (folha_recebida.relatorio == null)
                    {
                        cmd.Parameters.Add("@doc_folhadepagamento", SqlDbType.VarBinary).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@doc_folhadepagamento", SqlDbType.VarBinary).Value = folha_recebida.relatorio;
                    }
                    cmd.Parameters.AddWithValue("@valor_folhafinal", folha_recebida.valor_final);
                    cmd.Parameters.AddWithValue("@valor_desc_total", folha_recebida.valor_desconto);
                    cmd.Parameters.AddWithValue("@horas_trab", folha_recebida.horas_trabalhadas);
                    cmd.Parameters.AddWithValue("@salario_liq", folha_recebida.salario_liquido);
                    cmd.Parameters.AddWithValue("@periodo_inicio", folha_recebida.periodo_inicio);
                    cmd.Parameters.AddWithValue("@periodo_fim", folha_recebida.periodo_fim);
                    cmd.Parameters.AddWithValue("@status_folha", folha_recebida.status_folha);
                    cmd.Parameters.AddWithValue("@id_empresa", folha_recebida.id_empresa);
                    cmd.Parameters.AddWithValue("@mes_referencia", folha_recebida.mes_referencia);

                    // Defina o parâmetro id_folhadepagamento para identificar qual registro será atualizado.
                    cmd.Parameters.AddWithValue("@id_folhadepagamento", folha_recebida.id_folha);

                    // Execute o comando SQL para atualizar os dados no banco de dados
                    int atualizado = cmd.ExecuteNonQuery();

                    if (atualizado > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Lide com exceções aqui, se necessário
                return false;
            }
            return false;
        }

    }
}
