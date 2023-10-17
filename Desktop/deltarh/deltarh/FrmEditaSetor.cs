using System;
using System.Windows.Forms;
using delta_controle;
using delta_modelo;

namespace deltarh
{
    public partial class FrmEditaSetor : Form
    {
        public FrmEditaSetor()
        {
            InitializeComponent();
        }
        private void atualizarEmpresa()
        {
            FrmCadEmpresa empresa = new FrmCadEmpresa();
            empresa.btnOk.Visible = true;
            empresa.btnSalvar.Visible = false;
            empresa.btnLimpar.Visible = false;
            empresa.btnCancelar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlteraBanco altera = new AlteraBanco();

            mdlSetor setor = new mdlSetor();

            setor.id = Convert.ToInt32(txtId.Text);
           
            setor.nome = txtNome.Text;
            try
            {
                bool alterado = altera.AlterarSetor(setor);
                if(alterado)
                {
                    MessageBox.Show("Setor Alterado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    atualizarEmpresa();
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
    }
}
