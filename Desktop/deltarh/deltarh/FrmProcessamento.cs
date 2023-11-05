using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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

            //Associar a folha que veio do menu anterior
            this.folha_de_pagamento = folhaDePagamento;

            //Buscar a empresa para popular os campos e ficar disponível
            BuscarEmpresa();

            //Verifica se deverá ser criada uma nova folha ou buscar do banco
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
            decimal horas_totais = 0;
            decimal valor_bruto = 0;
            decimal descontos = 0;
            decimal valor_liquido = 0;

            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                horas_totais += folha_individual.horas_trabalhadas;
                valor_bruto += folha_individual.salario_base;
                descontos += folha_individual.valor_desconto;
                valor_liquido += folha_individual.salario_liquido;
            }

            folha_de_pagamento.horas_trabalhadas = horas_totais;
            folha_de_pagamento.salario_base = valor_bruto;
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

            dataGridFolhasIndividuais.Columns["salario_base"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["salario_base"].HeaderText = "Salário Bruto";

            dataGridFolhasIndividuais.Columns["valor_desconto"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["valor_desconto"].HeaderText = "Descontos Totais";

            dataGridFolhasIndividuais.Columns["salario_liquido"].DefaultCellStyle.Format = "N2";
            dataGridFolhasIndividuais.Columns["salario_liquido"].HeaderText = "Salário Líquido";

            dataGridFolhasIndividuais.Refresh();


            txtHorasTotais.Text = string.Format("{0:D2}:{1:D2}", (int)folha_de_pagamento.horas_trabalhadas, (int)((folha_de_pagamento.horas_trabalhadas - (int)folha_de_pagamento.horas_trabalhadas) * 60));
            txtValorBruto.Text = folha_de_pagamento.salario_base.ToString("N2");
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

        private void GerarRelatorio()
        {
            //Criar planilha com nome de aba e salvar em variável
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Folha de Pagamento");

            // Estilo criado para aplicar nas células desejadas, fundo verde claro, solido, fonte negrito
            ICellStyle headerStyle = workbook.CreateCellStyle();
            headerStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
            headerStyle.FillPattern = FillPattern.SolidForeground;
            IFont headerFont = workbook.CreateFont();
            headerFont.Boldweight = (short)FontBoldWeight.Bold;
            headerStyle.SetFont(headerFont);

            // Criar um estilo para os valores formatados como "R$ #,##0.00"
            ICellStyle currencyStyle = workbook.CreateCellStyle();
            currencyStyle.DataFormat = workbook.CreateDataFormat().GetFormat("R$ #,##0.00");

            // Crie um estilo para as horas formatadas como "hh:mm:ss"
            ICellStyle timeSpanStyle = workbook.CreateCellStyle();
            timeSpanStyle.DataFormat = workbook.CreateDataFormat().GetFormat("hh:mm:ss");

            // Adicionar os headers a planilha, após cada dado adicionado, é aplicado o estilo definido para header
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("RE");
            headerRow.GetCell(0).CellStyle = headerStyle;
            headerRow.CreateCell(1).SetCellValue("Nome Colaborador");
            headerRow.GetCell(1).CellStyle = headerStyle;
            headerRow.CreateCell(2).SetCellValue("Cargo");
            headerRow.GetCell(2).CellStyle = headerStyle;
            headerRow.CreateCell(3).SetCellValue("Periodo Inicio");
            headerRow.GetCell(3).CellStyle = headerStyle;
            headerRow.CreateCell(4).SetCellValue("Periodo Fim");
            headerRow.GetCell(4).CellStyle = headerStyle;
            headerRow.CreateCell(5).SetCellValue("Mes Ref");
            headerRow.GetCell(5).CellStyle = headerStyle;
            headerRow.CreateCell(6).SetCellValue("Carga Horaria");
            headerRow.GetCell(6).CellStyle = headerStyle;
            headerRow.CreateCell(7).SetCellValue("Horas Trabalhadas");
            headerRow.GetCell(7).CellStyle = headerStyle;
            headerRow.CreateCell(8).SetCellValue("Salário Bruto");
            headerRow.GetCell(8).CellStyle = headerStyle;
            headerRow.CreateCell(9).SetCellValue("Desconto IRRF");
            headerRow.GetCell(9).CellStyle = headerStyle;
            headerRow.CreateCell(10).SetCellValue("Desconto INSS");
            headerRow.GetCell(10).CellStyle = headerStyle;
            headerRow.CreateCell(11).SetCellValue("Descontos Totais");
            headerRow.GetCell(11).CellStyle = headerStyle;
            headerRow.CreateCell(12).SetCellValue("Salario Liquido");
            headerRow.GetCell(12).CellStyle = headerStyle;
            headerRow.CreateCell(13).SetCellValue("Status");
            headerRow.GetCell(13).CellStyle = headerStyle;

            //Salva somas totais em variaveis para jogar na ultima linha da planilha o fim do loop
            int rowIndex = 1;
            decimal totalCargaHoraria = 0;
            decimal totalHorasTrabalhadas = 0;
            double totalSalarioBruto = 0;
            double totalDescontoIRRF = 0;
            double totalDescontoINSS = 0;
            double totalDescontosTotais = 0;
            double totalSalarioLiquido = 0;

            //Faz loop na lista de folhas individuais, para cada folha é criada uma linha e adicionadas as informações
            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.CreateCell(0).SetCellValue(folha_individual.id_colaborador);
                dataRow.CreateCell(1).SetCellValue(folha_individual.nome_colaborador);
                dataRow.CreateCell(2).SetCellValue(folha_individual.cargo_colaborador);
                dataRow.CreateCell(3).SetCellValue(folha_individual.periodo_inicio.ToString("dd/MM/yyyy"));
                dataRow.CreateCell(4).SetCellValue(folha_individual.periodo_fim.ToString("dd/MM/yyyy"));
                dataRow.CreateCell(5).SetCellValue(folha_individual.mes_referencia);
                dataRow.CreateCell(6).SetCellValue(folha_individual.carga_horaria);

                // A cada linha adicionada, é adicionado também o style para a mesma
                ICell horasTrabalhadasCell = dataRow.CreateCell(7);
                horasTrabalhadasCell.SetCellValue((double)(folha_individual.horas_trabalhadas / 1440)); // Converter para fração do dia
                horasTrabalhadasCell.CellStyle = timeSpanStyle;

                ICell salarioBrutoCell = dataRow.CreateCell(8);
                salarioBrutoCell.SetCellValue((double)folha_individual.salario_base);
                salarioBrutoCell.CellStyle = currencyStyle;

                ICell descontoIrrfCell = dataRow.CreateCell(9);
                descontoIrrfCell.SetCellValue((double)folha_individual.desconto_irrf);
                descontoIrrfCell.CellStyle = currencyStyle;

                ICell descontoInssCell = dataRow.CreateCell(10);
                descontoInssCell.SetCellValue((double)folha_individual.desconto_inss);
                descontoInssCell.CellStyle = currencyStyle;

                ICell descontosTotaisCell = dataRow.CreateCell(11);
                descontosTotaisCell.SetCellValue((double)folha_individual.valor_desconto);
                descontosTotaisCell.CellStyle = currencyStyle;

                ICell salarioLiquidoCell = dataRow.CreateCell(12);
                salarioLiquidoCell.SetCellValue((double)folha_individual.salario_liquido);
                salarioLiquidoCell.CellStyle = currencyStyle;

                dataRow.CreateCell(13).SetCellValue(folha_individual.status);

                //Ao fim de cada iteração é acrescido o valor total de cada coluna para criação da linha de totais
                totalCargaHoraria += folha_individual.carga_horaria;
                totalHorasTrabalhadas += folha_individual.horas_trabalhadas;
                totalSalarioBruto += (double)folha_individual.salario_base;
                totalDescontoIRRF += (double)folha_individual.desconto_irrf;
                totalDescontoINSS += (double)folha_individual.desconto_inss;
                totalDescontosTotais += (double)folha_individual.valor_desconto;
                totalSalarioLiquido += (double)folha_individual.salario_liquido;

                //RowIndex necessário para o sistema saber qual vai ser a ultima linha e colocar os totais
                rowIndex++;
            }

            // Adicionar os totais no final da planilha
            IRow totalRow = sheet.CreateRow(rowIndex + 1);
            totalRow.CreateCell(3).SetCellValue("TOTAIS GERAIS:");
            totalRow.CreateCell(6).SetCellValue((double)totalCargaHoraria);

            ICell totalHorasTrabalhadasCell = totalRow.CreateCell(7);
            totalHorasTrabalhadasCell.SetCellValue((double)(totalHorasTrabalhadas / 1440)); // Converter para fração do dia
            totalHorasTrabalhadasCell.CellStyle = timeSpanStyle;

            ICell totalSalarioBrutoCell = totalRow.CreateCell(8);
            totalSalarioBrutoCell.SetCellValue(totalSalarioBruto);
            totalSalarioBrutoCell.CellStyle = currencyStyle;

            ICell totalDescontoIrrfCell = totalRow.CreateCell(9);
            totalDescontoIrrfCell.SetCellValue(totalDescontoIRRF);
            totalDescontoIrrfCell.CellStyle = currencyStyle;

            ICell totalDescontoInssCell = totalRow.CreateCell(10);
            totalDescontoInssCell.SetCellValue(totalDescontoINSS);
            totalDescontoInssCell.CellStyle = currencyStyle;

            ICell totalDescontosTotaisCell = totalRow.CreateCell(11);
            totalDescontosTotaisCell.SetCellValue(totalDescontosTotais);
            totalDescontosTotaisCell.CellStyle = currencyStyle;

            ICell totalSalarioLiquidoCell = totalRow.CreateCell(12);
            totalSalarioLiquidoCell.SetCellValue(totalSalarioLiquido);
            totalSalarioLiquidoCell.CellStyle = currencyStyle;

            //Escrever planilha em um memory stream e depois converter o memory strem para array de bytes, para que seja possível salvar no banco
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.Write(memoryStream);
                byte[] bytes = memoryStream.ToArray();

                folha_de_pagamento.relatorio = bytes;
            }
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

                GerarRelatorio();

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

        private void ProcessarFolha()
        {
            foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
            {
                mdlHolerite holerite = new mdlHolerite();
                holerite.PopularHolerite(folha_individual);

                CadHolerite cadHolerite = new CadHolerite();
                cadHolerite.InserirHolerite(holerite);
            }
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularFolha();
        }

        private void btnProcessaFolha_Click(object sender, EventArgs e)
        {
            folha_de_pagamento.status_folha = "Processado";

            ProcessarFolha();

            CadFolha cadFolha = new CadFolha();
            cadFolha.UpdateFolha(folha_de_pagamento);

            MessageBox.Show("Folha de pagamento processada com sucesso.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReiniciarFormulario();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dataGridFolhasIndividuais.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridFolhasIndividuais.SelectedRows[0].Index;
                mdlFolhaIndividual entidadeSelecionada = folhas_individuais[rowIndex];

                FrmFolhaIndividual folha = new FrmFolhaIndividual(entidadeSelecionada);
                folha.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada na DataGridView.");
            }
        }
    }
}
