using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace deltarh
{
    public partial class FrmColadorador : Form
    {
        public FrmColadorador()
        {
            InitializeComponent();
        }

        private void Coladorador_Load(object sender, EventArgs e)
        {

        }

        public void PopularEmpresas()
        {
            try
            {
                ConsultaBanco consulta = new ConsultaBanco();
                List<mdlEmpresa> empresas = consulta.ListarEmpresas();

                cboxEmpresas.DataSource = empresas;
                cboxEmpresas.DisplayMember = "razao";
                cboxEmpresas.ValueMember = "id";
            }
            catch (Exception)
            {
                
            }
        }

        public void BuscarColab()
        {
            string cpf = mskCpf.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlColaborador colab = null;

            try
            {
                colab = consulta.ConsultarColab(cpf);

                txtId.Text = Convert.ToString(colab.id);
                txtNome.Text = colab.nome;
                mskCpf.Text = colab.cpf;
                mskNascimento.Text = colab.nascimento.ToString("dd/MM/yyyy");
                txtSalario.Text = Convert.ToString(colab.salario);
                cboxTipoContrato.Text = colab.contrato;
                cboxHorario.Text = Convert.ToString(colab.cHoraria);
                txtLogradouro.Text = colab.logradouro;
                txtNumero.Text = colab.numero;
                txtComplemento.Text = colab.complemento;
                txtBairro.Text = colab.bairro;
                txtCep.Text = colab.cep;
                txtCidade.Text = colab.cidade;
                txtUf.Text = colab.uf;
                txtTelefone1.Text = colab.fone1;
                txtTelefone2.Text = colab.fone2;
                txtEmail.Text = colab.email;
                txtStatus.Text = colab.status;

                PopularEmpresas();
                cboxEmpresas.SelectedValue = colab.idEmpresa;
                txtCargo.Text = colab.cargo;
                mskAdmissao.Text = colab.data_admissao.ToString("dd/MM/yyyy");

                try
                {
                    List<mdlSetor> setores = new List<mdlSetor>();
                    setores = consulta.ConsultarSetor(colab.idEmpresa);

                    cBoxSetor.DataSource = setores;

                    cBoxSetor.DisplayMember = "nome";
                    cBoxSetor.ValueMember = "id";

                    cBoxSetor.SelectedValue = colab.id_setor;
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro ao buscar setores.", "ERRO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                
            }
            catch (Exception)
            {
                colab = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCadColadorador edita = new FrmCadColadorador();
            edita.mskCpf.Text = mskCpf.Text;
            edita.btnCadastrar.Visible = false;
            edita.btnSalvar.Visible = true;
            edita.BuscarColaborador();
            Close();
            edita.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarColab();
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarColab();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
