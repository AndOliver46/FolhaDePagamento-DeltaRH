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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
