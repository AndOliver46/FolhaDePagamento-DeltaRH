using delta_modelo;
using System;
using System.Windows.Forms;


namespace deltarh
{
    public partial class FrmRegras : Form
    {
        public FrmRegras()
        {
            InitializeComponent();
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("É necessário definir a Missão e a Política para Cadastrar a Empresa. Deseja mesmo Cancelar?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            mdlMissao missao = new mdlMissao();
            mdlPolitica politica = new mdlPolitica();

            missao.descricao = txtMissao.Text;
            politica.descricao = txtPolitica.Text;
        }
    }

}
