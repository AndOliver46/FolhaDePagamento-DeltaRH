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
        [DisplayName("Desconto IRRF")]
        public decimal desconto_irrf { get; set; }
        [DisplayName("Desconto INSS")]
        public decimal desconto_inss { get; set; }
        [DisplayName("Descontos Totais")]
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
        public mdlEmpresa empresa { get; set; }
        [Browsable(false)]
        public List<mdlPontoEletronico> pontos_eletronicos { get; set; }

        public void CalcularFolhaIndividual()
        {
            PopularDadosColaborador();

            CalcularHoras();
            CalcularDescontos();
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

        private void CalcularDescontos()
        {
            valor_desconto = 0;

            CalcularDescontosHoras();
            CalcularDescontosBeneficios();
            CalcularDescontosGoverno();
        }

        private void CalcularDescontosHoras()
        {
            double horas_totais = carga_horaria * 4;
            decimal valor_hora = valor_final / (decimal)horas_totais;

            TimeSpan horasComoTimeSpan = TimeSpan.FromHours(horas_totais);
            TimeSpan horas_calculadas = horasComoTimeSpan - horas_trabalhadas; //176 - 170 = -3

            if (horas_calculadas > TimeSpan.Zero)
            {
                if (colaborador.horas_banco > TimeSpan.Zero)
                {
                    //Logica banco de horas
                }

                decimal desconto_horas_devidas = (decimal)horas_calculadas.TotalHours * valor_hora;
                valor_desconto += desconto_horas_devidas;
            }
            else
            {
                colaborador.horas_banco += -horas_calculadas;
            }

            salario_liquido = valor_final - valor_desconto;
        }

        private void CalcularDescontosBeneficios()
        {
            decimal valor_descontos_beneficios = 0;

            valor_descontos_beneficios += salario_liquido * ((decimal)empresa.assMedica / 100);
            valor_descontos_beneficios += salario_liquido * ((decimal)empresa.odonto / 100);
            valor_descontos_beneficios += salario_liquido * ((decimal)empresa.vt / 100);
            valor_descontos_beneficios += salario_liquido * ((decimal)empresa.vr / 100);
            valor_descontos_beneficios += salario_liquido * ((decimal)empresa.gym / 100);

            salario_liquido = salario_liquido - valor_descontos_beneficios;
        }

        private void CalcularDescontosGoverno()
        {
            //Logica IRRF
            //Logica INSS
        }
    }
}
