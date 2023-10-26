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
        public string consulta = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);
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
            BuscarColaborador();
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
            AlteraBanco altera = new AlteraBanco();

            mdlColaborador colab = new mdlColaborador();

            colab.id = Convert.ToInt32(txtId.Text);

            colab.nome = txtNome.Text;
            colab.nascimento = Convert.ToDateTime(mskNascimento.Text);
            colab.cpf = mskCpf.Text;
            colab.contrato = cboxTipoContrato.Text;
            colab.salario = Convert.ToDecimal(txtSalario.Text);
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
            colab.status = cboxStatus.Text;
            colab.idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
            colab.cargo = txtCargo.Text;
            colab.horas_banco = TimeSpan.Zero;

            try
            {
                bool alterado = altera.AlterarColaborador(colab);
                if (alterado)
                {
                    MessageBox.Show("Cadastro Alterado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
                else
                {
                    MessageBox.Show("NÃO CADASTRADO.", "ERRO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BuscarSetor()
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            mdlColaborador colab = new mdlColaborador();
            try
            {
                colab.nome = txtNome.Text;
                colab.nascimento = Convert.ToDateTime(mskNascimento.Text);
                colab.cpf = mskCpf.Text;
                colab.contrato = cboxTipoContrato.Text;
                colab.salario = Convert.ToDecimal(txtSalario.Text);
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
                colab.status = cboxStatus.Text;
                colab.idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
                colab.cargo = txtCargo.Text;
                colab.horas_banco = TimeSpan.Zero;

                CadColab conecta = new CadColab();

                bool sucesso = conecta.CadastrarColab(colab);

                if (sucesso)
                {
                    DialogResult resposta = MessageBox.Show("Cadastro Realizado com Sucesso! Cadastrar Novo Colaborador?", "PARABÉNS!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmColadorador colab = new FrmColadorador();
            colab.BuscarColab();
        }

        public void BuscarColaborador()
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
                cboxStatus.Text = colab.status;
                txtCargo.Text = colab.cargo;
                txtIdEmpresa.Text = Convert.ToString(colab.idEmpresa);
                txtSenha.Text = colab.senha;

                cBoxSetor.Text = colab.setor.nome;
            }
            catch (Exception ex)
            {
                colab = null;
            }
        }

        private void cboxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
