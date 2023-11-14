using System;

namespace delta_modelo
{
    public class mdlHolerite
    {

        public int IdHolerite { get; set; }
        public string NomeEmpresa { get; set; }
        public string CnpjEmpresa { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public int IdFolhaDePagamento { get; set; }
        public int IdColaborador { get; set; }
        public string NomeColaborador { get; set; }
        public string CargoColaborador { get; set; }
        public decimal HorasTrabalhadas { get; set; }
        public decimal? PorcentagemVT { get; set; }
        public decimal? PorcentagemVR { get; set; }
        public decimal? PorcentagemAssisOdonto { get; set; }
        public decimal? PorcentagemAssisMedica { get; set; }
        public decimal? PorcentagemAdiantamento { get; set; }
        public decimal? PorcentagemGympass { get; set; }
        public decimal? HorasExtras { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal TotalVencimentos { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string MesAnoReferencia { get; set; }
        public decimal ValorHorasExtras { get; set; }
        public decimal HorasAtraso { get; set; }
        public decimal ValorHorasAtraso { get; set; }
        public decimal DescontoINSS { get; set; }
        public decimal DescontoIRRF { get; set; }


        public void PopularHolerite(mdlFolhaIndividual folha_individual)
        {
            NomeEmpresa = folha_individual.empresa.razao;
            CnpjEmpresa = folha_individual.empresa.cnpj;
            PeriodoInicio = folha_individual.periodo_inicio;
            PeriodoFim = folha_individual.periodo_fim;
            IdFolhaDePagamento = folha_individual.id_folhadepagamento;
            IdColaborador = folha_individual.colaborador.id;
            NomeColaborador = folha_individual.colaborador.nome;
            CargoColaborador = folha_individual.colaborador.cargo;
            HorasTrabalhadas = folha_individual.horas_trabalhadas;
            PorcentagemVT = folha_individual.empresa.vt;
            PorcentagemVR = folha_individual.empresa.vr;
            PorcentagemAssisOdonto = folha_individual.empresa.odonto;
            PorcentagemAssisMedica = folha_individual.empresa.assMedica;
            PorcentagemGympass = folha_individual.empresa.gym;
            PorcentagemAdiantamento = 0.0M;
            HorasExtras = folha_individual.horas_extras;
            SalarioBase = folha_individual.salario_base;
            TotalVencimentos = folha_individual.valor_vencimento;
            TotalDescontos = folha_individual.valor_desconto;
            SalarioLiquido = folha_individual.salario_liquido;
            MesAnoReferencia = folha_individual.mes_referencia;
            ValorHorasExtras = folha_individual.valor_horas_extras;
            HorasAtraso = folha_individual.horas_atraso;
            ValorHorasAtraso = folha_individual.valor_desc_atraso;
            DescontoINSS = folha_individual.desconto_inss;
            DescontoIRRF = folha_individual.desconto_irrf;
        }
    }
}
