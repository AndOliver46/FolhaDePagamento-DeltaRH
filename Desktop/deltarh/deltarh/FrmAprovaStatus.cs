using delta_controle;
using delta_modelo;
using System;
using System.Windows.Forms;

namespace deltarh
{
    public partial class FrmAprovaStatus : Form
    {
        public FrmAprovaStatus()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarEmpresa();
        }

        public void MostrarEmpresa()
        {
            ConsultaBanco consulta = new ConsultaBanco();

            mdlEmpresa empresa = new mdlEmpresa();

            try
            {
                empresa = consulta.ConsultarEmpresa(txtCnpj.Text);

                txtRazao.Text = empresa.razao;
                lblStatus.Text = empresa.status;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            AlteraBanco altera = new AlteraBanco();

            mdlEmpresa empresa = new mdlEmpresa();

            empresa.cnpj = txtCnpj.Text;
            empresa.status = "ATIVO";

            frmMenu menu = new frmMenu();
            try
            {
                bool alterado = altera.AlterarStatus(empresa);
                if (alterado)
                {
                    MessageBox.Show("Status Alterado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    menu.BuscarStatus();
                }
                else
                {
                    MessageBox.Show("Não Alterado.", "ERRO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            AlteraBanco altera = new AlteraBanco();

            mdlEmpresa empresa = new mdlEmpresa();

            empresa.cnpj = txtCnpj.Text;
            empresa.status = "INATIVO";

            frmMenu menu = new frmMenu();
            try
            {
                bool alterado = altera.AlterarStatus(empresa);
                if (alterado)
                {
                    MessageBox.Show("Status Alterado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    menu.BuscarStatus();

                }
                else
                {
                    MessageBox.Show("Não Alterado.", "ERRO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
