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
            DLL_CLASS_CNPJ.CNPJ cnpj = new DLL_CLASS_CNPJ.CNPJ();
            cnpj.mForm("99999999999999", "");
            Console.WriteLine(cnpj);
           // txtRazaoSocial.Text = DLL_CLASS_CNPJ.RazaoSocial;
        }
    }
}
