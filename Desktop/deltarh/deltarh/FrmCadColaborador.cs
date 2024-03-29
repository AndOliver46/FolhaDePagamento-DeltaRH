﻿using delta_controle;
using delta_modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ViaCep;

namespace deltarh
{
    public partial class FrmCadColadorador : Form
    {
        public string consulta = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);
        List<mdlEmpresa> empresas;
        public FrmCadColadorador()
        {
            InitializeComponent();
            ConsultaBanco consulta = new ConsultaBanco();
            empresas = consulta.ListarEmpresas();
            cboxEmpresas.DataSource = empresas;
            cboxEmpresas.DisplayMember = "razao";
            cboxEmpresas.ValueMember = "id";
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
            mskAdmissao.Text = "";

            mskCpf.Focus();
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
            colab.nascimento = DateTime.ParseExact(mskNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
            colab.idEmpresa = Convert.ToInt32(cboxEmpresas.SelectedValue);
            colab.cargo = txtCargo.Text;
            colab.horas_banco = 0;
            colab.data_admissao = DateTime.ParseExact(mskAdmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 

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
            catch (Exception)
            {
                throw;
            }
        }

        public void BuscarSetor()
        {
            int idEmpresa = Convert.ToInt32(cboxEmpresas.SelectedValue);

            ConsultaBanco consulta = new ConsultaBanco();

            try
            {
                List<mdlSetor> setores = new List<mdlSetor>();
                setores = consulta.ConsultarSetor(idEmpresa);

                cBoxSetor.DataSource = setores;

                cBoxSetor.DisplayMember = "nome";
                cBoxSetor.ValueMember = "id";
            }
            catch (Exception)
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
                colab.nascimento = DateTime.ParseExact(mskNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                colab.idEmpresa = Convert.ToInt32(cboxEmpresas.SelectedValue);
                colab.cargo = txtCargo.Text;
                colab.horas_banco = 0;
                colab.data_admissao = DateTime.ParseExact(mskAdmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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
            catch (Exception)
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
                cboxStatus.Text = colab.status;
                txtCargo.Text = colab.cargo;

                cboxEmpresas.SelectedValue = colab.idEmpresa;
                txtSenha.Text = colab.senha;
                mskAdmissao.Text = colab.data_admissao.ToString("dd/MM/yyyy");

                BuscarSetor();
                cBoxSetor.SelectedValue = colab.id_setor;
            }
            catch (Exception)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
