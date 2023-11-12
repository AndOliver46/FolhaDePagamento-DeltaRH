using delta_controle;
using delta_modelo;
using System;
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
                mskNascimento.Text = Convert.ToString(colab.nascimento);
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
                txtIdEmpresa.Text = Convert.ToString(colab.idEmpresa);

                txtSetor.Text = colab.setor.nome;

                MostrarEmpresa();
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
            edita.BuscarSetor();
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

        private void MostrarEmpresa()
        {
            int idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);

            ConsultaBanco consulta = new ConsultaBanco();

            mdlEmpresa empresa = new mdlEmpresa();

            try
            {
                empresa = consulta.ConsultarEmpresaId(idEmpresa);

                txtEmpresa.Text = empresa.razao;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
