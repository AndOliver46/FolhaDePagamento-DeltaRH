using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
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

            //Associei a folha que veio do menu anterior
            this.folha_de_pagamento = folhaDePagamento;

            //Busco a empresa para popular os campos e ficar disponível
            BuscarEmpresa();

            //Verifica se deverá ser criada uma nova folha ou buscada do banco
            CriarOuBuscarFolha();

            //Com a folha principal e folhas individuais buscadas, realizar somas totais
            RealizarSomasTotais();

            //Carregar todos os dados buscados e calculados na view
            CarregarViewComDados();

            RecalcularFolha();
        }

        private void BuscarEmpresa()
        {
            ConsultaBanco consulta = new ConsultaBanco();
            empresa = consulta.ConsultarEmpresaId(folha_de_pagamento.id_empresa);
        }

        private void CriarOuBuscarFolha()
        {
            if (folha_de_pagamento.id_folha == 0)
            {
                CriarFolha();
            }
            else
            {
                BuscarFolha();
            }
        }

        private void CriarFolha()
        {
            CadFolha cadFolha = new CadFolha();
            cadFolha.CadastrarFolha(folha_de_pagamento);

            ConsultaBanco consulta = new ConsultaBanco();

            this.folha_de_pagamento = consulta.BuscarFolha(folha_de_pagamento.id_empresa, folha_de_pagamento.mes_referencia);
            this.folhas_individuais = consulta.GerarFolhasIndividuais(empresa, folha_de_pagamento.id_folha, folha_de_pagamento.periodo_inicio, folha_de_pagamento.periodo_fim, folha_de_pagamento.mes_referencia);
        }

        private void BuscarFolha()
        {
            ConsultaBanco consulta = new ConsultaBanco();

            this.folha_de_pagamento = consulta.BuscarFolha(folha_de_pagamento.id_empresa, folha_de_pagamento.mes_referencia);
            this.folhas_individuais = consulta.BuscarFolhasIndividuais(empresa, folha_de_pagamento.id_folha);
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

            folha_de_pagamento.horas_trabalhadas = horas_totais;
            folha_de_pagamento.valor_final = valor_bruto;
            folha_de_pagamento.valor_desconto = descontos;
            folha_de_pagamento.salario_liquido = valor_liquido;

            CadFolha cadFolha = new CadFolha();
            cadFolha.UpdateFolha(folha_de_pagamento);
        }

        private void CarregarViewComDados()
        {
            PopularCamposFolhaPagamento();
            AjustarComportamentoBotoes();
        }

        private void PopularCamposFolhaPagamento()
        {
            txtId.Text = Convert.ToString(folha_de_pagamento.id_folha);
            txtStatus.Text = folha_de_pagamento.status_folha;
            txtMesReferencia.Text = folha_de_pagamento.mes_referencia;
            txtInicio.Text = folha_de_pagamento.periodo_inicio.ToString("dd/MM/yyyy");
            txtTermino.Text = folha_de_pagamento.periodo_fim.ToString("dd/MM/yyyy");

            dataGridFolhasIndividuais.DataSource = folhas_individuais;

            dataGridFolhasIndividuais.Columns["valor_final"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["valor_final"].HeaderText = "Salário Bruto";

            dataGridFolhasIndividuais.Columns["valor_desconto"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["valor_desconto"].HeaderText = "Descontos Totais";

            dataGridFolhasIndividuais.Columns["salario_liquido"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["salario_liquido"].HeaderText = "Salário Líquido";

            dataGridFolhasIndividuais.Refresh();


            txtHorasTotais.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)folha_de_pagamento.horas_trabalhadas.TotalHours, folha_de_pagamento.horas_trabalhadas.Minutes, folha_de_pagamento.horas_trabalhadas.Seconds);
            txtValorBruto.Text = folha_de_pagamento.valor_final.ToString("N2");
            txtDescontos.Text = folha_de_pagamento.valor_desconto.ToString("N2");
            txtValorLiquido.Text = folha_de_pagamento.salario_liquido.ToString("N2");

            txtEmpresa.Text = Convert.ToString(empresa.razao);
        }

        private void AjustarComportamentoBotoes()
        {
            switch (folha_de_pagamento.status_folha.ToLower())
            {
                case "pendente":
                    btnSolicitarAprovacao.Enabled = false;
                    btnProcessaFolha.Enabled = false;
                    btnRecalcular.Enabled = false;
                    break;

                case "aprovado":
                    btnSolicitarAprovacao.Enabled = false;
                    btnProcessaFolha.Enabled = true;
                    btnRecalcular.Enabled = false;
                    break;

                case "reprovado":
                case "rascunho":
                    btnSolicitarAprovacao.Enabled = true;
                    btnProcessaFolha.Enabled = false;
                    btnRecalcular.Enabled = true;
                    break;

                case "processado":
                    btnSolicitarAprovacao.Enabled = false;
                    btnProcessaFolha.Enabled = false;
                    btnRecalcular.Enabled = false;
                    break;

                default:
                    MessageBox.Show("Status inválido, contatar administrador.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ReiniciarFormulario()
        {
            this.Close();
            FrmProcessamento novoForm = new FrmProcessamento(folha_de_pagamento);
            novoForm.Show();
        }

        private void RecalcularFolha()
        {
            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                folha_individual.CalcularFolhaIndividual();
            }

            RealizarSomasTotais();
            PopularCamposFolhaPagamento();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool pronto_para_aprovar = true;

            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                if (folha_individual.status == "Pendente")
                {
                    pronto_para_aprovar = false;
                    break;
                }
            }

            if (pronto_para_aprovar)
            {
                folha_de_pagamento.status_folha = "Pendente";
                CadFolha cadFolha = new CadFolha();
                cadFolha.UpdateFolha(folha_de_pagamento);

                MessageBox.Show("Solicitação de aprovação enviada ao cliente.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReiniciarFormulario();
            }
            else
            {
                MessageBox.Show("Ainda há folhas individuais não aprovadas, aprove e tente novamente.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularFolha();
        }
    }
}
