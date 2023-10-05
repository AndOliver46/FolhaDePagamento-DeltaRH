using System;
using System.Windows.Forms;
using delta_controle;
using delta_modelo;
using DLL_CLASS_CNPJ;

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

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCadColadorador edita = new FrmCadColadorador();
            edita.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

                txtSetor.Text = colab.setor.nome;

                // txtIdEmpresa.Text = colab.id.Text;
                // txtEmpresa.Text = 
            }
            catch (Exception ex)
            {
                colab = null;
            }


        }
    }
}
