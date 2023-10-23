using System;
using System.Windows.Forms;
using delta_modelo;
using delta_controle;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace deltarh
{
    public partial class FrmCadEmpresa : Form
    {
        public FrmCadEmpresa()
        {
            InitializeComponent();
        }

        public void limparCadastro()
        {
            txtCnpj.Text = "";
            txtRazaoSocial.Text = "";
            txtFantasia.Text = "";
            txtSituacao.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtUf.Text = "";
            txtCidade.Text = "";
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtEmail.Text = "";
            txtMissao.Text = "";
            txtPolitica.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            txtCpf.Text = "";
            txtCodId.Text = "";
            txtStatus.Text = "";

            txtCnpj.Focus();
        }

        public void consultaCnpj()
        {
            string cnpj = txtCnpj.Text;

            ConsultaBanco consulta = new ConsultaBanco();

            mdlEmpresa empresa = null;

            try
            {
                empresa = consulta.ConsultarEmpresa(cnpj);
                txtMissao.Text = empresa.missao.descricao;
                txtPolitica.Text = empresa.politica.descricao;

                txtCodId.Text = Convert.ToString(empresa.id);
                txtRazaoSocial.Text = empresa.razao;
                txtCnpj.Text = empresa.cnpj;
                txtNome.Text = empresa.responsavel;
                txtCpf.Text = empresa.cpf;
                txtStatus.Text = empresa.status;
                txtLogradouro.Text = empresa.logradouro;
                txtNumero.Text = empresa.numero;
                txtComplemento.Text = empresa.complemento;
                txtBairro.Text = empresa.bairro;
                txtCep.Text = empresa.cep;
                txtCidade.Text = empresa.cidade;
                txtUf.Text = empresa.uf;
                txtTelefone1.Text = empresa.fone1;
                txtTelefone2.Text = empresa.fone2;
                txtEmail.Text = empresa.email;
                txtSenha.Text = empresa.senha;
                txtVt.Text = Convert.ToString(empresa.vt);
                txtVr.Text = Convert.ToString(empresa.vr);
                txtAssMedica.Text = Convert.ToString(empresa.assMedica);
                txtOdonto.Text = Convert.ToString(empresa.odonto);
                txtGym.Text = Convert.ToString(empresa.gym);

                txtRazaoSocial.Enabled = false;
                txtUsuario.Text = txtCnpj.Text;

                ListarSetores();
            }
            catch (Exception ex)
            {
                empresa = null;
            }
        }

        public void editar()
        {
            gboxEndereco.Enabled = true;
            gboxContato.Enabled = true;
            gboxDesconto.Enabled = true;
            gboxCadastro.Enabled = true;
            gboxEdita.Enabled = true;
            gboxMissao.Enabled = true;
            gboxPolitica.Enabled = true;
            txtFantasia.Enabled = true;
            txtCnpj.Enabled = false;
            btnSalvar.Visible = true;
            btnLimpar.Visible = true;
            btnCancelar.Visible = true;
            btnOk.Visible = false;
            btnEditar.Visible = false;
            btnConsultaCnpj.Visible = false;
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

        public void ObterCnpj()
        {
            var cnpj = Empresa.ObterCnpj(txtCnpj.Text);

            if (cnpj != null && cnpj.status != "ERROR")
            {
                txtRazaoSocial.Text = cnpj.nome;
                txtFantasia.Text = cnpj.fantasia;
                txtSituacao.Text = cnpj.situacao;
                txtLogradouro.Text = cnpj.logradouro;
                txtNumero.Text = cnpj.numero;
                txtComplemento.Text = cnpj.complemento;
                txtBairro.Text = cnpj.bairro;
                txtCep.Text = cnpj.cep;
                txtUf.Text = cnpj.uf;
                txtCidade.Text = cnpj.municipio;
                txtTelefone1.Text = cnpj.telefone;
                txtEmail.Text = cnpj.email;

                txtUsuario.Text = txtCnpj.Text;
            }
            else
            {

                MessageBox.Show("CNPJ Não Encontrado na Base da Receita Federal!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCadastro();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEditaSetor edita = new FrmEditaSetor();
            edita.txtId.Text = txtEditaSetor.Text;
            edita.ShowDialog();
            consultaCnpj();

            btnOk.Visible = true;
            btnSalvar.Visible = false;
            btnLimpar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        public void btnConsultaCnpj_Click(object sender, EventArgs e)
        {
            consultaCnpj();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AlteraBanco altera = new AlteraBanco();

            mdlEmpresa empresa = new mdlEmpresa();
            mdlMissao missao = new mdlMissao();
            mdlPolitica politica = new mdlPolitica();

            empresa.id = Convert.ToInt32(txtCodId.Text);

            missao.descricao = txtMissao.Text;
            politica.descricao = txtPolitica.Text;

            empresa.razao = txtRazaoSocial.Text;
            empresa.cnpj = txtCnpj.Text;
            empresa.responsavel = txtNome.Text;
            empresa.cpf = txtCpf.Text;
            empresa.logradouro = txtLogradouro.Text;
            empresa.numero = txtNumero.Text;
            empresa.complemento = txtComplemento.Text;
            empresa.bairro = txtBairro.Text;
            empresa.cep = txtCep.Text;
            empresa.cidade = txtCidade.Text;
            empresa.uf = txtUf.Text;
            empresa.fone1 = txtTelefone1.Text;
            empresa.fone2 = txtTelefone2.Text;
            empresa.email = txtEmail.Text;
            empresa.senha = txtSenha.Text;
            empresa.status = txtStatus.Text;
            empresa.vt = Convert.ToDecimal(txtVt.Text);
            empresa.vr = Convert.ToDecimal(txtVr.Text);
            empresa.assMedica = Convert.ToDecimal(txtAssMedica.Text);
            empresa.odonto = Convert.ToDecimal(txtOdonto.Text);
            empresa.gym = Convert.ToDecimal(txtGym.Text);

            try
            {
                bool alterado = altera.AlterarEmpresa(missao, politica, empresa);
                if (alterado)
                {
                    MessageBox.Show("Cadastro Alterado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.txtCnpj.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mdlSetor setor = new mdlSetor();
            
            try
            {
                setor.nome = txtSetor.Text;
                setor.idEmpresa = Convert.ToInt32(txtCodId.Text);

                CadSetor conecta = new CadSetor();

                conecta.CadastrarSetor(setor);

                MessageBox.Show("Setor Cadastrado com Sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtSetor.Text = "";
                txtSetor.Focus();

                consultaCnpj();

                btnOk.Visible = true;
                btnSalvar.Visible = false;
                btnLimpar.Visible = false;
                btnCancelar.Visible = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
            ListarSetores();
        }

        private void setorToolStripButton_Click(object sender, EventArgs e)
        {


        }

        public void ListarSetores()
        {
            StringConexao conecta = new StringConexao();
            string consulta = conecta.stringSql;

            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                conexaodb.Open();

                var sqlQuery = "SELECT id_setor, nome_setor FROM tbl_setor WHERE id_empresa = @id_empresa";

                SqlCommand cmd = new SqlCommand(sqlQuery, conexaodb);

                cmd.Parameters.AddWithValue("@id_empresa", txtCodId.Text);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();



                da.Fill(dt);

                gridSetor.DataSource = dt;
                gridSetor.Columns[0].Width = 100;
                gridSetor.Columns[1].Width = 200;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            mdlMissao missao = new mdlMissao();
            mdlPolitica politica = new mdlPolitica();
            mdlEmpresa empresa = new mdlEmpresa();
            mdlSetor setor = new mdlSetor();
            string nomeSetor = "Geral";

            try
            {
                missao.descricao = txtMissao.Text;
                politica.descricao = txtPolitica.Text;

                empresa.razao = txtRazaoSocial.Text;
                empresa.cnpj = txtCnpj.Text;
                empresa.responsavel = txtNome.Text;
                empresa.cpf = txtCpf.Text;
                empresa.logradouro = txtLogradouro.Text;
                empresa.numero = txtNumero.Text;
                empresa.complemento = txtComplemento.Text;
                empresa.bairro = txtBairro.Text;
                empresa.cep = txtCep.Text;
                empresa.cidade = txtCidade.Text;
                empresa.uf = txtUf.Text;
                empresa.fone1 = txtTelefone1.Text;
                empresa.fone2 = txtTelefone2.Text;
                empresa.email = txtEmail.Text;
                empresa.senha = txtSenha.Text;
                empresa.vt = Convert.ToDecimal(txtVt.Text);
                empresa.vr = Convert.ToDecimal(txtVr.Text);
                empresa.assMedica = Convert.ToDecimal(txtAssMedica.Text);
                empresa.odonto = Convert.ToDecimal(txtOdonto.Text);
                empresa.gym = Convert.ToDecimal(txtGym.Text);

                setor.nome = nomeSetor;

                if (txtStatus.Text == "")
                {
                    empresa.status = "PENDENTE";
                }
                else
                {
                    empresa.status = txtStatus.Text;
                }

                Conexao conecta = new Conexao();

                conecta.CadastrarEmpresa(missao, politica, empresa, setor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult resposta = MessageBox.Show("Cadastro Realizado com Sucesso! Cadastrar Nova Empresa?", "PARABÉNS!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resposta == DialogResult.Yes)
            {
                limparCadastro();
            }
            else
            {
                Close();
            }
        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                consultaCnpj();
            }
        }

        private void chbVt_CheckedChanged(object sender, EventArgs e)
        {
            txtVt.Enabled = chbVt.Checked;
        }

        private void chbVr_CheckedChanged(object sender, EventArgs e)
        {
            txtVr.Enabled = chbVr.Checked;
        }

        private void chbAssMedica_CheckedChanged(object sender, EventArgs e)
        {
            txtAssMedica.Enabled = chbAssMedica.Checked;
        }

        private void chbOdonto_CheckedChanged(object sender, EventArgs e)
        {
            txtOdonto.Enabled = chbOdonto.Checked;
        }

        private void chbGym_CheckedChanged(object sender, EventArgs e)
        {
            txtGym.Enabled = chbGym.Checked;
        }

        private void gridSetor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
