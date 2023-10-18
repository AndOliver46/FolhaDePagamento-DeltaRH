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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void EntrarMenu()
        {
            frmMenu menu = new frmMenu();

            if (txtUsuario.Text == "admin" && mskSenha.Text == "admin")
            {

                menu.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Text = "";
                mskSenha.Text = "";
                txtUsuario.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EntrarMenu();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void mskSenha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.SetStyle(ControlStyles.StandardClick, true);
            EntrarMenu();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void mskSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                EntrarMenu();
            }
        }
    }
}
