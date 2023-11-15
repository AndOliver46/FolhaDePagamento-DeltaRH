using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        public decimal horas_trabalhadas { get; set; }
        [DisplayName("Horas Extras")]
        public decimal horas_extras { get; set; }
        [DisplayName("Valor H.E")]
        public decimal valor_horas_extras { get; set; }
        [DisplayName("Atrasos")]
        public decimal horas_atraso { get; set; }
        [DisplayName("Desconto Atrasos")]
        public decimal valor_desc_atraso { get; set; }
        [DisplayName("Salário Bruto")]
        public decimal salario_base { get; set; }
        [DisplayName("Desconto Beneficios")]
        public decimal desconto_beneficios { get; set; }
        [DisplayName("Desconto IRRF")]
        public decimal desconto_irrf { get; set; }
        [DisplayName("Desconto INSS")]
        public decimal desconto_inss { get; set; }
        [DisplayName("Vencimentos Totais")]
        public decimal valor_vencimento { get; set; }
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

            SomarPontosEletronicos();
            CalcularValorHoras();
            CalcularDescontosBeneficios();
            CalcularDescontosObrigatórios();
            CalcularSalarioLiquido();
        }

        private void PopularDadosColaborador()
        {
            id_colaborador = colaborador.id;
            nome_colaborador = colaborador.nome;
            carga_horaria = colaborador.cHoraria;
            salario_base = colaborador.salario;
            cargo_colaborador = colaborador.cargo;
        }

        private void SomarPontosEletronicos()
        {
            horas_atraso = 0;
            horas_extras = 0;
            horas_trabalhadas = 0;

            int dias_trabalhados = 0;
            int dias_esperados = ObterDiasUteis(periodo_inicio);

            decimal horas_esperadas = 0;
            switch (carga_horaria)
            {
                case 80:
                    horas_esperadas = 4; break;
                case 120:
                    horas_esperadas = 6; break;
                case 220:
                    horas_esperadas = 8; break;
            }

            foreach (mdlPontoEletronico ponto in pontos_eletronicos)
            {
                if (ponto.abono)
                {
                    horas_trabalhadas += horas_esperadas;
                }
                else
                {
                    if (ponto.entrada != TimeSpan.Zero && ponto.saida != TimeSpan.Zero &&
                        ponto.saida_almoco != TimeSpan.Zero && ponto.retorno_almoco != TimeSpan.Zero)
                    {
                        decimal horas_dia = 0;

                        TimeSpan tempoAlmoco = (TimeSpan)ponto.retorno_almoco - (TimeSpan)ponto.saida_almoco;
                        TimeSpan horasTrabalhadas = (TimeSpan)ponto.saida - (TimeSpan)ponto.entrada;

                        horas_dia = (decimal)(horasTrabalhadas.TotalMinutes - tempoAlmoco.TotalMinutes) / 60;

                        if (ponto.data.DayOfWeek == DayOfWeek.Saturday || ponto.data.DayOfWeek == DayOfWeek.Sunday)
                        {
                            horas_extras += horas_dia;
                        }
                        else
                        {
                            decimal calculo_horas = horas_dia - horas_esperadas; //7.30 - 8 = -0.30
                            if (calculo_horas >= 0)
                            {
                                horas_extras += calculo_horas;
                            }
                            else
                            {
                                horas_atraso += calculo_horas;
                            }
                            horas_trabalhadas += horas_dia;
                        }
                    }
                }
                dias_trabalhados++;
            }

            if (horas_extras > horas_atraso)
            {
                horas_extras = horas_extras - horas_atraso;
                horas_atraso = 0;
            }
            else if (horas_atraso > horas_extras)
            {
                horas_atraso = horas_atraso - horas_extras;
                horas_extras = 0;
            }
            else
            {
                horas_atraso = 0;
                horas_extras = 0;
            }

            if (dias_trabalhados < dias_esperados)
            {
                int faltas = dias_esperados - dias_trabalhados;

                horas_atraso += faltas * horas_esperadas;
            }
        }

        private void CalcularValorHoras()
        {
            valor_horas_extras = 0;
            valor_desc_atraso = 0;

            decimal valor_hora = salario_base / carga_horaria; //Salario base / carga horaria

            valor_horas_extras = horas_extras * (valor_hora * 1.5m);
            valor_desc_atraso = horas_atraso * valor_hora;

            valor_vencimento = salario_base + valor_horas_extras;
            valor_desconto = valor_desc_atraso;
        }

        private void CalcularDescontosBeneficios()
        {
            desconto_beneficios = 0;

            desconto_beneficios += salario_base * ((decimal)empresa.assMedica / 100);
            desconto_beneficios += salario_base * ((decimal)empresa.odonto / 100);
            desconto_beneficios += salario_base * ((decimal)empresa.vt / 100);
            desconto_beneficios += salario_base * ((decimal)empresa.vr / 100);
            desconto_beneficios += salario_base * ((decimal)empresa.gym / 100);

            valor_desconto += desconto_beneficios;
        }

        private void CalcularDescontosObrigatórios()
        {
            /*  INSS: Para salários de até R$ 1.100,00: 7,5%
                De R$ 1.100,01 a R$ 2.203,48: 9%
                De R$ 2.203,49 a R$ 3.672,29: 12%
                De R$ 3.672,30 a R$ 6.244,48: 14%
                Acima de R$ 6.244,48: R$ 751,99 (valor fixo)
            */

            decimal salario = valor_vencimento; // salario_base pelo valor do salário que você deseja calcular
            desconto_inss = 0;
            desconto_irrf = 0;

            // Definição das alíquotas do INSS em 2023
            decimal aliquotaAte1100 = 0.075m;
            decimal aliquotaDe1101Ate2203 = 0.09m;
            decimal aliquotaDe2204Ate3305 = 0.12m;
            decimal aliquotaAcima3305 = 0.14m;

            // Definição dos limites para cada faixa de alíquota
            decimal limiteFaixa1 = 1320.00m;
            decimal limiteFaixa2 = 2571.29m;
            decimal limiteFaixa3 = 3856.94m;

            if (salario <= limiteFaixa1)
            {
                desconto_inss = salario * aliquotaAte1100;
            }
            else if (salario <= limiteFaixa2)
            {
                desconto_inss = (limiteFaixa1 * aliquotaAte1100) + ((salario - limiteFaixa1) * aliquotaDe1101Ate2203);
            }
            else if (salario <= limiteFaixa3)
            {
                desconto_inss = (limiteFaixa1 * aliquotaAte1100) + ((limiteFaixa2 - limiteFaixa1) * aliquotaDe1101Ate2203) + ((salario - limiteFaixa2) * aliquotaDe2204Ate3305);
            }
            else if (salario <= 6244.48m)
            {
                desconto_inss = salario * 0.14m;
            }
            else
            {
                desconto_inss = (limiteFaixa1 * aliquotaAte1100) + ((limiteFaixa2 - limiteFaixa1) * aliquotaDe1101Ate2203) + ((limiteFaixa3 - limiteFaixa2) * aliquotaDe2204Ate3305) + ((salario - limiteFaixa3) * aliquotaAcima3305);
            }

            /*
                IRRF
                Até R$ 1.903,98: Isento
                De R$ 1.903,99 a R$ 2.826,65: 7,5%
                De R$ 2.826,66 a R$ 3.751,05: 15%
                De R$ 3.751,06 a R$ 4.664,68: 22,5%
                Acima de R$ 4.664,68: 27,5%
             */

            // Definição das alíquotas do IRRF em 2023
            decimal aliquotaFaixa1 = 0.075m;
            decimal aliquotaFaixa2 = 0.15m;
            decimal aliquotaFaixa3 = 0.225m;
            decimal aliquotaFaixa4 = 0.275m;

            // Definição dos limites para cada faixa de alíquota
            decimal limiteFaixaIRRF1 = 2112.00m;
            decimal limiteFaixaIRRF2 = 2826.65m;
            decimal limiteFaixaIRRF3 = 3751.06m;
            decimal limiteFaixaIRRF4 = 4664.68m;

            decimal baseCalculo = salario - desconto_inss;


            if (baseCalculo > limiteFaixaIRRF1)
            {
                desconto_irrf += (Math.Min(baseCalculo, limiteFaixaIRRF2) - limiteFaixaIRRF1) * aliquotaFaixa1;
            }
            if (baseCalculo > limiteFaixaIRRF2)
            {
                desconto_irrf += (Math.Min(baseCalculo, limiteFaixaIRRF3) - limiteFaixaIRRF2) * aliquotaFaixa2;
            }
            if (baseCalculo > limiteFaixaIRRF3)
            {
                desconto_irrf += (Math.Min(baseCalculo, limiteFaixaIRRF4) - limiteFaixaIRRF3) * aliquotaFaixa3;
            }
            if (baseCalculo > limiteFaixaIRRF4)
            {
                desconto_irrf += (baseCalculo - limiteFaixaIRRF4) * aliquotaFaixa4;
            }

            valor_desconto += desconto_irrf + desconto_inss;
        }

        private void CalcularSalarioLiquido()
        {
            salario_liquido = valor_vencimento - valor_desconto;
        }

        private int ObterDiasUteis(DateTime data)
        {
            int diasUteis = 0;
            int totalDiasNoMes = DateTime.DaysInMonth(data.Year, data.Month);

            for (int dia = 1; dia <= totalDiasNoMes; dia++)
            {
                DateTime dataAtual = new DateTime(data.Year, data.Month, dia);

                if (dataAtual.DayOfWeek != DayOfWeek.Saturday && dataAtual.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasUteis++;
                }
            }

            return diasUteis;
        }
    }
}
