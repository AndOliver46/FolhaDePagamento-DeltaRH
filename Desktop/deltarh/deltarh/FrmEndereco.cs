using System;
using System.Windows.Forms;

namespace deltarh
{
    public partial class FrmEndereco : Form
    {

        /*private void LocalizaCep()
        {
                if (!string.IsNullOrWhiteSpace(txtCep.Text))
                {
                    var viaCepService = ViaCepService.Default();
                    var endereco = viaCepService.ObterEndereco(txtCep.Text);

                    if (endereco.Cep != null)
                    {
                        txtLogradouro.Text = endereco.Logradouro;
                        txtBairro.Text = endereco.Bairro;
                        txtCidade.Text = endereco.Localidade;
                        txtUf.Text = endereco.UF;
                    }
                    else
                    {
                        MessageBox.Show("CEP Não Localizado!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um CEP Válido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }       
        }*/
        public FrmEndereco()
        {
            InitializeComponent();
        }

        private void btnCep_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            /*  txtLogradouro.Text = "";
              txtBairro.Text = "";
              txtCidade.Text = "";
              txtUf.Text = "";
              txtNumero = "";
              txtComplemento = "";

              txtCep.Focus;*/
        }
    }
}
