using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deltarh
{
    public partial class FrmProcessamento : Form
    {
        public mdlFolhaDePagamento folha_de_pagamento;
        private List<mdlFolhaIndividual> folhas_individuais;
        private mdlEmpresa empresa;

        public FrmProcessamento(mdlFolhaDePagamento folhaDePagamento)
        {
            InitializeComponent();
            this.folha_de_pagamento = folhaDePagamento;

            if (folha_de_pagamento.id_folha == 0)
            {
                CadFolha cadFolha = new CadFolha();
                cadFolha.CadastrarFolha(folhaDePagamento);

                ConsultaBanco consulta = new ConsultaBanco();
                this.folha_de_pagamento = consulta.BuscarFolha(folhaDePagamento.id_empresa, folhaDePagamento.mes_referencia);

                GerarFolhasIndividuais();
            }
            else
            {
                BuscarFolhasIndividuais();
            }

            PopularCamposFolhaPagamento();
            PopularCamposEmpresa();
            RealizarSomasTotais();
        }

        private void PopularCamposFolhaPagamento()
        {
            txtId.Text = Convert.ToString(folha_de_pagamento.id_folha);
            txtStatus.Text = folha_de_pagamento.status_folha;
            txtMesReferencia.Text = folha_de_pagamento.mes_referencia;
            txtInicio.Text = folha_de_pagamento.periodo_inicio.ToString("dd/MM/yyyy");
            txtTermino.Text = folha_de_pagamento.periodo_fim.ToString("dd/MM/yyyy");
        }

        private void PopularCamposEmpresa()
        {
            ConsultaBanco consulta = new ConsultaBanco();
            empresa = consulta.ConsultarEmpresaId(folha_de_pagamento.id_empresa);

            txtEmpresa.Text = Convert.ToString(empresa.razao);
        }

        private void GerarFolhasIndividuais()
        {
            ConsultaBanco consulta = new ConsultaBanco();
            folhas_individuais = consulta.GerarFolhasIndividuais(folha_de_pagamento.id_empresa, folha_de_pagamento.id_folha, folha_de_pagamento.periodo_inicio, folha_de_pagamento.periodo_fim, folha_de_pagamento.mes_referencia);
            dataGridFolhasIndividuais.DataSource = folhas_individuais;
        }

        private void BuscarFolhasIndividuais()
        {
            ConsultaBanco consulta = new ConsultaBanco();
            folhas_individuais = consulta.BuscarFolhasIndividuais(folha_de_pagamento.id_folha);
            dataGridFolhasIndividuais.DataSource = folhas_individuais;
        }

        private void RealizarSomasTotais()
        {
            TimeSpan horas_totais = TimeSpan.Zero;
            decimal valor_bruto = 0;
            decimal descontos = 0;
            decimal valor_liquido = 0;

            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                horas_totais += folha_individual.horas_trabalhadas;
                valor_bruto += folha_individual.valor_final;
                descontos += folha_individual.valor_desconto;
                valor_liquido += folha_individual.salario_liquido;
            }

            txtHorasTotais.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)horas_totais.TotalHours, horas_totais.Minutes, horas_totais.Seconds);
            txtValorBruto.Text = Convert.ToString(valor_bruto);
            txtDescontos.Text = Convert.ToString(descontos);
            txtValorLiquido.Text = Convert.ToString(valor_liquido);
        }

        private void SalvarRascunhoFolha()
        {

        }
    }
}
