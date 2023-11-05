using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    [horas_extras],
                    [salario_base],
                    [total_vencimentos],
                    [total_descontos],
                    [salario_liq],
                    [mes_ano_ref]
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
                    @HorasExtras,
                    @SalarioBase,
                    @TotalVencimentos,
                    @TotalDescontos,
                    @SalarioLiquido,
                    @MesAnoReferencia
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
                    command.Parameters.Add("@HorasTrabalhadas", SqlDbType.Time).Value = holerite.HorasTrabalhadas;
                    command.Parameters.Add("@PorcentagemVT", SqlDbType.Decimal).Value = holerite.PorcentagemVT;
                    command.Parameters.Add("@PorcentagemVR", SqlDbType.Decimal).Value = holerite.PorcentagemVR;
                    command.Parameters.Add("@PorcentagemAssisOdonto", SqlDbType.Decimal).Value = holerite.PorcentagemAssisOdonto;
                    command.Parameters.Add("@PorcentagemAssisMedica", SqlDbType.Decimal).Value = holerite.PorcentagemAssisMedica;
                    command.Parameters.Add("@PorcentagemAdiantamento", SqlDbType.Decimal).Value = holerite.PorcentagemAdiantamento;
                    command.Parameters.Add("@HorasExtras", SqlDbType.Time).Value = holerite.HorasExtras;
                    command.Parameters.Add("@SalarioBase", SqlDbType.Decimal).Value = holerite.SalarioBase;
                    command.Parameters.Add("@TotalVencimentos", SqlDbType.Decimal).Value = holerite.TotalVencimentos;
                    command.Parameters.Add("@TotalDescontos", SqlDbType.Decimal).Value = holerite.TotalDescontos;
                    command.Parameters.Add("@SalarioLiquido", SqlDbType.Decimal).Value = holerite.SalarioLiquido;
                    command.Parameters.Add("@MesAnoReferencia", SqlDbType.VarChar, 25).Value = holerite.MesAnoReferencia;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
