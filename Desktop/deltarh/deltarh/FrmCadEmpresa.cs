using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace deltarh
{
    public partial class FrmCadEmpresa : Form
    {
        public FrmCadEmpresa()
        {
            InitializeComponent();
        }

        private void btnEditarEnd_Click(object sender, EventArgs e)
        {
            FrmEndereco end = new FrmEndereco();
            end.ShowDialog();

        }

        private void btnEditarDp_Click(object sender, EventArgs e)
        {
            FrmCadDp dp = new FrmCadDp();
            dp.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Deseja Importar Todos os Dados da Base da Receita Federal?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resposta == DialogResult.Yes)
            {
                ObterCnpj();
            }
            
        }

        private void ObterCnpj()
        {
            var cnpj = Empresa.ObterCnpj(txtCnpj.Text);

            if (cnpj != null)
            {
               txtRazaoSocial.Text = cnpj.nome;
               txtFantasia.Text = cnpj.fantasia;
               txtSituacao.Text = cnpj.situacao;
               txtLogradouro.Text = cnpj.logradouro;
               txtNumero.Text = cnpj.numero;
               txtComplemento.Text = cnpj.complemento;
               txtBairro.Text = cnpj.bairro;
               txtCep.Text = cnpj.cep;
               txtUf.Text = cnpj.uf;
               txtCidade.Text = cnpj.municipio;
               txtTelefone1.Text = cnpj.telefone;
               txtEmail.Text = cnpj.email;
            }

                else
                {
                    MessageBox.Show("CNPJ Inválido!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCnpj.Text = "";
            txtRazaoSocial.Text = "";
            txtFantasia.Text = "";
            txtSituacao.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtUf.Text = "";
            txtCidade.Text = "";

           // txtCnpj.;
        }
    }
}
