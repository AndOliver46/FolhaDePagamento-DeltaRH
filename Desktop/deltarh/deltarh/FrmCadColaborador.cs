using System;
using System.Collections.Generic;
using ViaCep;
using System.Windows.Forms;
using CpfLibrary;
using delta_controle;
using delta_modelo;
using DLL_CLASS_CNPJ;

namespace deltarh
{
    public partial class FrmCadColadorador : Form
    {
        public string consulta = @"Data Source=desktop-dk36nf7\sqlexpress;Initial Catalog=BD_DELTA;Integrated Security=True";
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
                colab.nascimento = Convert.ToDateTime(mskNascimento.Text);
                colab.cpf = mskCpf.Text;
                colab.contrato = cboxTipoContrato.Text;
                colab.salario = Convert.ToDouble(txtSalario.Text);
                colab.senha = txtSenha.Text;
                colab.cHoraria = Convert.ToInt32(cboxHorario.Text);
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
                colab.id_setor = Convert.ToInt32(cBoxSetor.SelectedValue);

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

        private void BuscarSetor()
        {
            int idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);

            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlSetor> setores = new List<mdlSetor>();

            mdlEmpresa empresa = new mdlEmpresa();

            try
            {
                setores = consulta.ConsultarSetor(idEmpresa);

                cBoxSetor.DataSource = setores;

                this.cBoxSetor.DisplayMember = "nome";
                this.cBoxSetor.ValueMember = "id";

                empresa = consulta.ConsultarEmpresaId(idEmpresa);

                txtEmpresa.Text = empresa.razao;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            BuscarSetor();
        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            var result = new ViaCepClient().Search(txtCep.Text); //searches for the postal code 01001-000
            txtLogradouro.Text = result.Street;
            txtCidade.Text = result.City;
            txtBairro.Text = result.Neighborhood;
            txtUf.Text = result.StateInitials;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
