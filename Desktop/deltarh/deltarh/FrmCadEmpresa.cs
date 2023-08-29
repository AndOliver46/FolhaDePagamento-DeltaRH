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
    }
}
