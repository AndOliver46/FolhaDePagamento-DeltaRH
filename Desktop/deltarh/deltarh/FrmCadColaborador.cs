using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpfLibrary;
using delta_controle;
using delta_modelo;

namespace deltarh
{
    public partial class FrmCadColadorador : Form
    {
        public FrmCadColadorador()
        {
            InitializeComponent();
        }

        public void LimparCadastro()
        {
            mskCpf.Text = "";
            txtNome.Text = "";
            mskNascimento.Text = "";
            txtSalario.Text = "";
            cboxTipoContrato.Text = "";
            cboxHorario.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtUf.Text = "";
            txtCidade.Text = "";
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtEmail.Text = "";

            mskCpf.Focus();
        }

        private void Coladorador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cpf.Check("29594421134");    // True
            Cpf.Check("488.081.131-91"); // True
            Cpf.Check("00000000000");    // False
            Cpf.Check("lol");            // False

            Cpf.Format("29594421134"); // "295.944.211-34"
            Cpf.Format("lol");         // "lol"
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimparCadastro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mdlColaborador colab = new mdlColaborador();
            try
            {
                colab.nome = txtNome.Text;
                colab.nascimento = mskNascimento.Text;
                colab.cpf = mskCpf.Text;
                colab.contrato = cboxTipoContrato.Text;
                colab.salario = txtSalario.Text;
                colab.senha = txtSenha.Text;
                colab.cHoraria = cboxHorario.Text;
                colab.logradouro = txtLogradouro.Text;
                colab.numero = txtNumero.Text;
                colab.complemento = txtComplemento.Text;
                colab.bairro = txtBairro.Text;
                colab.cep = txtCep.Text;
                colab.cidade = txtCidade.Text;
                colab.uf = txtUf.Text;
                colab.fone1 = txtTelefone1.Text;
                colab.fone2 = txtTelefone2.Text;
                colab.email = txtEmail.Text;
                colab.id_setor = txtSetor.Text;

                CadColab conecta = new CadColab();

                conecta.CadastrarColab(colab);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult resposta = MessageBox.Show("Cadastro Realizado com Sucesso! Cadastrar Nova Empresa?", "PARABÉNS!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resposta == DialogResult.Yes)
            {
                LimparCadastro();
            }
            else
            {
                Close();
            }
        }
    }
}
