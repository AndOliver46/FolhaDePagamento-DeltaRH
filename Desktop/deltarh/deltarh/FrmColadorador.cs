using System;
using System.Windows.Forms;

namespace deltarh
{
    public partial class FrmColadorador : Form
    {
        public FrmColadorador()
        {
            InitializeComponent();
        }

        private void Coladorador_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCadColadorador edita = new FrmCadColadorador();
            edita.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
