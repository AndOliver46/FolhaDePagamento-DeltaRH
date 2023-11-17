using System;
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

            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
            }
            if (txtUsuario.Text == "admin" && mskSenha.Text == "admin")
            {
                if(progressBar1.Value == 99)
                {
                    menu.ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Text = "";
                mskSenha.Text = "";
                txtUsuario.Focus();
            }
            Console.WriteLine(progressBar1.Value);
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
            SetStyle(ControlStyles.StandardClick, true);
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
