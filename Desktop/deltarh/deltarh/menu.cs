using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using delta_controle;
using delta_modelo;

namespace deltarh
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCnpj_Click(object sender, EventArgs e)
        {
            string cnpj = txtCnpj.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlEmpresa empresa = null;

            try
            {
                empresa = consulta.ConsultarEmpresa(cnpj);

                if (empresa == null)
                {
                    var resposta = MessageBox.Show("Empresa não cadastrada. Deseja cadastrá-la?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        FrmCadEmpresa cadastro = new FrmCadEmpresa();
                        cadastro.txtCnpj.Text = cnpj;
                        cadastro.ObterCnpj();
                        cadastro.editar();
                        cadastro.ShowDialog();
                    }
                }
                else
                {
                    FrmCadEmpresa cadastro = new FrmCadEmpresa();
                    cadastro.txtCnpj.Text = cnpj;
                    cadastro.consultaCnpj();
                    cadastro.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                empresa = null;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmColadorador colab = new FrmColadorador();
            colab.ShowDialog();
        }
    }
}
