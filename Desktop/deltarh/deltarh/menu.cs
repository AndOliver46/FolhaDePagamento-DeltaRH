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
using DLL_CLASS_CNPJ;

namespace deltarh
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        public void ListarEmpresa()
        {
            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlEmpresa> empresas = new List<mdlEmpresa>();

            try
            {
                empresas = consulta.ListarEmpresas();

                cBoxEmpresa.DataSource = empresas;

                this.cBoxEmpresa.DisplayMember = "razao";
                this.cBoxEmpresa.ValueMember = "id";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BuscarSetor()
        {
            int idEmpresa = Convert.ToInt32(cBoxEmpresa.SelectedValue);

            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlSetor> setores = new List<mdlSetor>();

            try
            {
                setores = consulta.ConsultarSetor(idEmpresa);

            }
            catch (Exception ex)
            {
                throw;
            }

            BuscarColabs(setores);
        }

        public void BuscarColabs(List<mdlSetor> setores)
        {
            ConsultaBanco consulta = new ConsultaBanco();

            List<mdlColaborador> colabs = new List<mdlColaborador>();
            foreach (mdlSetor setor in setores)
            {
                try
                {
                    int id_setor = setor.id;
                    List<mdlColaborador> colaboradores = consulta.ListarColaborador(id_setor);
                    colabs.AddRange(colaboradores);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            cBoxColaborador.DataSource = colabs;

            this.cBoxColaborador.DisplayMember = "nome";
            this.cBoxColaborador.ValueMember = "id";
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
            string cpf = txtCpf.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlColaborador colab = null;

                colab = consulta.ConsultarColab(cpf);

                if (colab == null)
                {
                    var resposta = MessageBox.Show("Colaborador não cadastrado. Deseja cadastrá-lo?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        FrmCadColadorador cadastro = new FrmCadColadorador();
                        cadastro.mskCpf.Text = cpf;
                        cadastro.ShowDialog();
                    }
                }
                else
                {
                    FrmColadorador busca = new FrmColadorador();
                    busca.mskCpf.Text = cpf;
                    busca.BuscarColab();
                    busca.ShowDialog();
                }
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            ListarEmpresa();
            BuscarSetor();
            BuscarStatus();
        }

        public void BuscarStatus()
        {
            try
            {
                this.tbl_empresaTableAdapter.status(this.bD_DELTADataSet.tbl_empresa);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            BuscarStatus();
        }

        private void statusToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_empresaTableAdapter.status(this.bD_DELTADataSet.tbl_empresa);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.StandardClick, true);
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            BuscarSetor();
        }
    }
}
