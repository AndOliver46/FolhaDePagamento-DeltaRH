using delta_modelo;
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
    public partial class FrmFolhaIndividual : Form
    {
        private mdlFolhaIndividual folhaIndividual;
        private mdlPontoEletronico ponto_selecionado;
        public FrmFolhaIndividual(mdlFolhaIndividual folha)
        {
            InitializeComponent();

            this.folhaIndividual = folha;

            PopularForm();
        }

        private void PopularForm()
        {
            txtEmpresa.Text = folhaIndividual.empresa.razao;
            txtNome.Text = folhaIndividual.colaborador.nome;
            txtCargo.Text = folhaIndividual.colaborador.cargo;
            txtRef.Text = folhaIndividual.mes_referencia;
            txtSalarioBase.Text = Convert.ToString(folhaIndividual.colaborador.salario);
            txtHorasExtras.Text = Convert.ToString(folhaIndividual.valor_horas_extras);
            txtAtrasos.Text = Convert.ToString(folhaIndividual.valor_desc_atraso);
            txtSalarioBruto.Text = Convert.ToString(folhaIndividual.valor_vencimento);
            txtDescontos.Text = Convert.ToString(folhaIndividual.valor_desconto);
            txtSalarioLiquido.Text = Convert.ToString(folhaIndividual.salario_liquido);
            //txtBeneficios.Text = 

            gridPontos.DataSource = folhaIndividual.pontos_eletronicos;
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void SelecionarPonto(object sender, EventArgs e)
        {
            if (gridPontos.SelectedRows.Count > 0)
            {
                int rowIndex = gridPontos.SelectedRows[0].Index;
                ponto_selecionado = folhaIndividual.pontos_eletronicos[rowIndex];

                txtData.Text = Convert.ToString(ponto_selecionado.data);
                txtEntrada.Text = Convert.ToString(ponto_selecionado.entrada);
                txtSaidaAlmoco.Text = Convert.ToString(ponto_selecionado.saida_almoco);
                txtRetornoAlmoco.Text = Convert.ToString(ponto_selecionado.retorno_almoco);
                txtSaida.Text = Convert.ToString(ponto_selecionado.saida);
                txtJustificativa.Text = ponto_selecionado.tipo_justificativa;
                txtDescricao.Text = ponto_selecionado.descricao;

                TimeSpan tempoAlmoco = (TimeSpan)ponto_selecionado.retorno_almoco - (TimeSpan)ponto_selecionado.saida_almoco;
                TimeSpan horasTrabalhadas = (TimeSpan)ponto_selecionado.saida - (TimeSpan)ponto_selecionado.entrada;

                txtHorasTrabalhadas.Text = Convert.ToString(horasTrabalhadas);
                txtTempoAlmoco.Text = Convert.ToString(tempoAlmoco);
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void picBoxComprovante_Click(object sender, EventArgs e)
        {

        }

        private void FrmFolhaIndividual_Load(object sender, EventArgs e)
        {

        }
    }
}
