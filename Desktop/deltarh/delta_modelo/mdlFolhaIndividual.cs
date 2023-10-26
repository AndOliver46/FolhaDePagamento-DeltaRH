using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_modelo
{
    public class mdlFolhaIndividual
    {
        //Dados colaborador
        [DisplayName("ID Colaborador")]
        public int id_colaborador { get; set; }
        [DisplayName("Nome Colaborador")]
        public string nome_colaborador { get; set; }
        [DisplayName("Cargo")]
        public string cargo_colaborador { get; set; }
        [DisplayName("Carga Horaria")]
        public int carga_horaria { get; set; }


        //Dados folha individual
        [DisplayName("Horas Trabalhadas")]
        public TimeSpan horas_trabalhadas { get; set; }
        [DisplayName("Salário Bruto")]
        public decimal valor_final { get; set; }
        [DisplayName("Descontos")]
        public decimal valor_desconto { get; set; }
        [DisplayName("Salario Liquido")]
        public decimal salario_liquido { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }


        //Itens a serem ocultados do datagrid
        [Browsable(false)]
        public int id_folhadepagamento { get; set; }
        [Browsable(false)]
        public string mes_referencia { get; set; }
        [Browsable(false)]
        public int id_folhaindividual { get; set; }
        [Browsable(false)]
        public DateTime periodo_inicio { get; set; }
        [Browsable(false)]
        public DateTime periodo_fim { get; set; }
        [Browsable(false)]
        public mdlColaborador colaborador { get; set; }
        [Browsable(false)]
        public List<mdlPontoEletronico> pontos_eletronicos { get; set; }

        public void PopularFolhaExistente()
        {
            PopularDadosColaborador();
            CalcularHoras();
        }

        public void CalcularNovaFolha()
        {
            PopularDadosColaborador();
            CalcularHoras();
            this.status = "Pendente";
        }

        private void PopularDadosColaborador()
        {
            this.id_colaborador = colaborador.id;
            this.nome_colaborador = colaborador.nome;
            this.carga_horaria = colaborador.cHoraria;
            this.valor_final = colaborador.salario;
            this.cargo_colaborador = colaborador.cargo;
        }

        private void CalcularHoras()
        {
            horas_trabalhadas = TimeSpan.Zero;

            foreach (mdlPontoEletronico ponto in this.pontos_eletronicos)
            {
                if (ponto.entrada != TimeSpan.Zero && ponto.saida != TimeSpan.Zero &&
                    ponto.saida_almoco != TimeSpan.Zero && ponto.retorno_almoco != TimeSpan.Zero)
                {
                    TimeSpan horas_dia = TimeSpan.Zero;

                    TimeSpan tempoAlmoco = (TimeSpan)ponto.retorno_almoco - (TimeSpan)ponto.saida_almoco;
                    TimeSpan horasTrabalhadas = (TimeSpan)ponto.saida - (TimeSpan)ponto.entrada;

                    horas_dia = horasTrabalhadas - tempoAlmoco;

                    this.horas_trabalhadas = this.horas_trabalhadas + horas_dia;
                }
            }
        }
    }
}
