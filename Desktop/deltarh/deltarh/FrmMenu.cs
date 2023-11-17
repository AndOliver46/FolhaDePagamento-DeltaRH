using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace deltarh
{
    public partial class frmMenu : Form
    {
        private List<mdlFolhaDePagamento> folhas_pagamento;
        private DataTable dt = new DataTable();

        public frmMenu()
        {
            InitializeComponent();
            ListarFolhasDePagamento();
        }

        public void ListarEmpresa()
        {
            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlEmpresa> empresas = new List<mdlEmpresa>();

            try
            {
                empresas = consulta.ListarEmpresas();

                cboxRazao.DataSource = empresas;
                cboxRazao.DisplayMember = "razao";
                cboxRazao.ValueMember = "id";

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ListarFolhasDePagamento()
        {
            ConsultaBanco consulta = new ConsultaBanco();
            folhas_pagamento = consulta.BuscarFolhasDePagamento();

            dataGridFolhaDePagamento.DataSource = folhas_pagamento;
            dataGridFolhaDePagamento.Refresh();
        }

        /*public void BuscarSetor()
        {
            if (cBoxEmpresa.SelectedValue is int)
            {
                int idEmpresa = Convert.ToInt32(cBoxEmpresa.SelectedValue);


                ConsultaBanco consulta = new ConsultaBanco();

                List<mdlSetor> setores = new List<mdlSetor>();

                try
                {
                    setores = consulta.ConsultarSetor(idEmpresa);

                }
                catch (Exception ex)
                {
                    throw;
                }

                BuscarColabs(setores);
            }
        }*/

        public void BuscarColabs(List<mdlSetor> setores)
        {
            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlColaborador> colabs = new List<mdlColaborador>();
            foreach (mdlSetor setor in setores)
            {
                try
                {
                    int id_setor = setor.id;
                    List<mdlColaborador> colaboradores = consulta.ListarColaborador(id_setor);
                    colabs.AddRange(colaboradores);

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void ConsultarEmpresas()
        {
            string cnpj = txtCnpj.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlEmpresa empresa = null;

            try
            {
                empresa = consulta.ConsultarEmpresa(cnpj);

                if (empresa == null)
                {
                    var resposta = MessageBox.Show("Empresa não cadastrada. Deseja cadastrá-la?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        FrmCadEmpresa cadastro = new FrmCadEmpresa();
                        cadastro.txtCnpj.Text = cnpj;
                        cadastro.ObterCnpj();
                        cadastro.editar();
                        cadastro.btnSalvar.Visible = false;
                        cadastro.btnCadastrar.Visible = true;
                        cnpj = "";
                        cadastro.gboxCadastro.Enabled = false;
                        cadastro.gboxEdita.Enabled = false;
                        cadastro.ShowDialog();
                    }
                }
                else
                {
                    FrmCadEmpresa cadastro = new FrmCadEmpresa();
                    cadastro.txtCnpj.Text = cnpj;
                    cadastro.consultaCnpj();
                    cadastro.ShowDialog();
                }
            }
            catch (Exception)
            {
                empresa = null;
            }
        }

        private void btnCnpj_Click(object sender, EventArgs e)
        {
            ConsultarEmpresas();
        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultarEmpresas();
            }
        }

        private void ConsultarColaborador()
        {
            string cpf = txtCpf.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlColaborador colab = null;

            colab = consulta.ConsultarColab(cpf);

            if (colab == null)
            {
                var resposta = MessageBox.Show("Colaborador não cadastrado. Deseja cadastrá-lo?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    FrmCadColadorador cadastro = new FrmCadColadorador();
                    cadastro.mskCpf.Text = cpf;
                    cadastro.ShowDialog();
                }
            }
            else
            {
                FrmColadorador busca = new FrmColadorador();
                busca.mskCpf.Text = cpf;
                busca.BuscarColab();
                busca.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarColaborador();
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultarColaborador();
            }
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            ListarEmpresa();
            BuscarStatus();
        }

        public void BuscarStatus()
        {
            StringConexao conecta = new StringConexao();
            string consulta = conecta.stringSql;

            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                conexaodb.Open();

                var sqlQuery = "SELECT cnpj, razao_social, status FROM tbl_empresa WHERE status = 'Pendente'";

                SqlCommand cmd = new SqlCommand(sqlQuery, conexaodb);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                gridPendentes.DataSource = dt;
                gridPendentes.Columns[0].Width = 105;
                gridPendentes.Columns[0].HeaderCell.Value = "CNPJ";
                gridPendentes.Columns[1].Width = 260;
                gridPendentes.Columns[0].HeaderCell.Value = "Razao Social";
                gridPendentes.Columns[2].Width = 105;
                gridPendentes.Columns[0].HeaderCell.Value = "Status";

            }
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            BuscarStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridPendentes.SelectedRows.Count > 0)
            {
                int selectedrowindex = gridPendentes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = gridPendentes.Rows[selectedrowindex];
                string cnpj = Convert.ToString(selectedRow.Cells["cnpj"].Value);

                FrmAprovaStatus status = new FrmAprovaStatus();
                status.txtCnpj.Text = cnpj;
                status.MostrarEmpresa();
                status.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma empresa na lista acima para alterar o status.", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BuscarPonto();
        }

        public void BuscarPonto()
        {
            StringConexao conecta = new StringConexao();
            string consulta = conecta.stringSql;

            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                //  int idcolab = Convert.ToInt32(cBoxColaborador.SelectedValue);
                conexaodb.Open();

                var sqlQuery = "SELECT id_colaborador, data, entrada, saida_almoco, retorno_almoco, saida FROM tbl_pontoeletronico WHERE id_colaborador = @idcolab";

                SqlCommand cmd = new SqlCommand(sqlQuery, conexaodb);

                //cmd.Parameters.AddWithValue("@idcolab", idcolab);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                gridPendentes.DataSource = dt;
                gridPendentes.Columns[0].Width = 40;
                gridPendentes.Columns[1].Width = 70;
                gridPendentes.Columns[2].Width = 70;
                gridPendentes.Columns[3].Width = 70;
                gridPendentes.Columns[4].Width = 70;
                gridPendentes.Columns[5].Width = 70;
            }
        }

        private void cBoxColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void btnJustificar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            int id_empresa = Convert.ToInt32(cboxRazao.SelectedValue);
            string mes = cboxMes.Text;
            string ano = cboxAno.Text;

            string mes_referencia = mes + "/" + ano;
            DateTime[] dias = GetFirstAndLastDayOfMonth(mes, ano);


            ConsultaBanco consulta = new ConsultaBanco();
            mdlFolhaDePagamento folha_existente = consulta.BuscarFolha(id_empresa, mes_referencia);

            if (folha_existente != null)
            {
                var resposta = MessageBox.Show("Folha do mês " + mes_referencia + " ja cadastrada. Abrir consulta?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    FrmProcessamento processa = new FrmProcessamento(folha_existente);
                    processa.ShowDialog();
                }
            }
            else
            {
                var resposta = MessageBox.Show("Folha do mês " + mes_referencia + " ainda não cadastrada. Deseja cadastrar?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    mdlFolhaDePagamento folha = new mdlFolhaDePagamento();
                    folha.id_empresa = id_empresa;
                    folha.mes_referencia = mes + "/" + ano;
                    folha.periodo_inicio = dias[0];
                    folha.periodo_fim = dias[1];
                    folha.salario_liquido = 0.0M;
                    folha.salario_base = 0.0M;
                    folha.valor_desconto = 0.0M;
                    folha.horas_trabalhadas = 0;
                    folha.relatorio = null;
                    folha.status_folha = "Rascunho";

                    FrmProcessamento processa = new FrmProcessamento(folha);
                    processa.ShowDialog();
                }
            }

        }

        private DateTime[] GetFirstAndLastDayOfMonth(string month, string year)
        {
            CultureInfo cultureInfo = new CultureInfo("pt-BR");

            string formattedMonth = cultureInfo.DateTimeFormat.GetMonthName(Array.IndexOf(cultureInfo.DateTimeFormat.AbbreviatedMonthNames, month.ToLower()) + 1);
            DateTime firstDayOfMonth = DateTime.ParseExact($"01-{formattedMonth}-{year}", "dd-MMMMM-yyyy", cultureInfo);
            int lastDay = DateTime.DaysInMonth(int.Parse(year), firstDayOfMonth.Month);
            DateTime lastDayOfMonth = DateTime.ParseExact($"{lastDay}-{formattedMonth}-{year}", "dd-MMMMM-yyyy", cultureInfo);

            return new DateTime[] { firstDayOfMonth, lastDayOfMonth };
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (dataGridFolhaDePagamento.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridFolhaDePagamento.SelectedRows[0].Index;
                mdlFolhaDePagamento entidadeSelecionada = folhas_pagamento[rowIndex];

                FrmProcessamento processa = new FrmProcessamento(entidadeSelecionada);
                processa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhuma folha de pagamento foi selecionada.", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListarEmpresa();
            ListarFolhasDePagamento();
        }
    }
}
