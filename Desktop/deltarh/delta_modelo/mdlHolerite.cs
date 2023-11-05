using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal? HorasExtras { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal TotalVencimentos { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string MesAnoReferencia { get; set; }


        public void PopularHolerite(mdlFolhaIndividual folha_individual)
        {
            this.NomeEmpresa = folha_individual.empresa.razao;
            this.CnpjEmpresa = folha_individual.empresa.cnpj;
            this.PeriodoInicio = folha_individual.periodo_inicio;
            this.PeriodoFim = folha_individual.periodo_fim;
            this.IdFolhaDePagamento = folha_individual.id_folhadepagamento;
            this.IdColaborador = folha_individual.colaborador.id;
            this.NomeColaborador = folha_individual.colaborador.nome;
            this.CargoColaborador = folha_individual.colaborador.cargo;
            this.HorasTrabalhadas = folha_individual.horas_trabalhadas;
            this.PorcentagemVT = folha_individual.empresa.vt;
            this.PorcentagemVR = folha_individual.empresa.vr;
            this.PorcentagemAssisOdonto = folha_individual.empresa.odonto;
            this.PorcentagemAssisMedica = folha_individual.empresa.assMedica;
            this.PorcentagemAdiantamento = 0.0M;
            this.HorasExtras = folha_individual.horas_extras;
            this.SalarioBase = folha_individual.salario_base;
            this.TotalVencimentos = folha_individual.valor_vencimento;
            this.TotalDescontos = folha_individual.valor_desconto;
            this.SalarioLiquido = folha_individual.salario_liquido;
            this.MesAnoReferencia = folha_individual.mes_referencia;
        }
    }
}
