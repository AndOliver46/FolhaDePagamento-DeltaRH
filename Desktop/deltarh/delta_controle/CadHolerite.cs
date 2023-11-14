using delta_modelo;
using System.Data;
using System.Data.SqlClient;

namespace delta_controle
{
    public class CadHolerite
    {
        StringConexao conecta = new StringConexao();

        public void InserirHolerite(mdlHolerite holerite)
        {
            using (SqlConnection connection = new SqlConnection(conecta.stringSql))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO [dbo].[tbl_holerite] (
                    [nome_empresa],
                    [cnpj_empresa],
                    [periodo_inicio],
                    [periodo_fim],
                    [id_folhadepagamento],
                    [id_colaborador],
                    [nome_colaborador],
                    [cargo_colaborador],
                    [horas_trab],
                    [porcentagem_vt],
                    [porcentagem_vr],
                    [porcentagem_assis_odonto],
                    [porcentagem_assis_medica],
                    [porcentagem_adiantamento],
                    [porcentagem_gympass],
                    [horas_extras],
                    [salario_base],
                    [total_vencimentos],
                    [total_descontos],
                    [salario_liq],
                    [mes_ano_ref],
                    [valor_horas_extras],
                    [horas_atraso],
                    [valor_desc_atrasos],
                    [desconto_inss],
                    [desconto_irrf]
                ) VALUES (
                    @NomeEmpresa,
                    @CnpjEmpresa,
                    @PeriodoInicio,
                    @PeriodoFim,
                    @IdFolhaDePagamento,
                    @IdColaborador,
                    @NomeColaborador,
                    @CargoColaborador,
                    @HorasTrabalhadas,
                    @PorcentagemVT,
                    @PorcentagemVR,
                    @PorcentagemAssisOdonto,
                    @PorcentagemAssisMedica,
                    @PorcentagemAdiantamento,
                    @PorcentagemGympass,
                    @HorasExtras,
                    @SalarioBase,
                    @TotalVencimentos,
                    @TotalDescontos,
                    @SalarioLiquido,
                    @MesAnoReferencia,
                    @ValorHorasExtras,
                    @HorasAtraso,
                    @ValorHorasAtraso,
                    @DescontoINSS,
                    @DescontoIRRF
                )";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.Add("@NomeEmpresa", SqlDbType.VarChar, 70).Value = holerite.NomeEmpresa;
                    command.Parameters.Add("@CnpjEmpresa", SqlDbType.VarChar, 20).Value = holerite.CnpjEmpresa;
                    command.Parameters.Add("@PeriodoInicio", SqlDbType.Date).Value = holerite.PeriodoInicio;
                    command.Parameters.Add("@PeriodoFim", SqlDbType.Date).Value = holerite.PeriodoFim;
                    command.Parameters.Add("@IdFolhaDePagamento", SqlDbType.Int).Value = holerite.IdFolhaDePagamento;
                    command.Parameters.Add("@IdColaborador", SqlDbType.Int).Value = holerite.IdColaborador;
                    command.Parameters.Add("@NomeColaborador", SqlDbType.VarChar, 70).Value = holerite.NomeColaborador;
                    command.Parameters.Add("@CargoColaborador", SqlDbType.VarChar, 50).Value = holerite.CargoColaborador;
                    command.Parameters.Add("@HorasTrabalhadas", SqlDbType.Decimal).Value = holerite.HorasTrabalhadas;
                    command.Parameters.Add("@PorcentagemVT", SqlDbType.Decimal).Value = holerite.PorcentagemVT;
                    command.Parameters.Add("@PorcentagemVR", SqlDbType.Decimal).Value = holerite.PorcentagemVR;
                    command.Parameters.Add("@PorcentagemAssisOdonto", SqlDbType.Decimal).Value = holerite.PorcentagemAssisOdonto;
                    command.Parameters.Add("@PorcentagemAssisMedica", SqlDbType.Decimal).Value = holerite.PorcentagemAssisMedica;
                    command.Parameters.Add("@PorcentagemAdiantamento", SqlDbType.Decimal).Value = holerite.PorcentagemAdiantamento;
                    command.Parameters.Add("@PorcentagemGympass", SqlDbType.Decimal).Value = holerite.PorcentagemGympass;
                    command.Parameters.Add("@HorasExtras", SqlDbType.Decimal).Value = holerite.HorasExtras;
                    command.Parameters.Add("@SalarioBase", SqlDbType.Decimal).Value = holerite.SalarioBase;
                    command.Parameters.Add("@TotalVencimentos", SqlDbType.Decimal).Value = holerite.TotalVencimentos;
                    command.Parameters.Add("@TotalDescontos", SqlDbType.Decimal).Value = holerite.TotalDescontos;
                    command.Parameters.Add("@SalarioLiquido", SqlDbType.Decimal).Value = holerite.SalarioLiquido;
                    command.Parameters.Add("@MesAnoReferencia", SqlDbType.VarChar, 25).Value = holerite.MesAnoReferencia;
                    command.Parameters.Add("@ValorHorasExtras", SqlDbType.Decimal).Value = holerite.ValorHorasExtras;
                    command.Parameters.Add("@HorasAtraso", SqlDbType.Decimal).Value = holerite.HorasAtraso;
                    command.Parameters.Add("@ValorHorasAtraso", SqlDbType.Decimal).Value = holerite.ValorHorasAtraso;
                    command.Parameters.Add("@DescontoINSS", SqlDbType.Decimal).Value = holerite.DescontoINSS;
                    command.Parameters.Add("@DescontoIRRF", SqlDbType.Decimal).Value = holerite.DescontoIRRF;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
