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
        public FrmFolhaIndividual(mdlFolhaIndividual folha)
        {
            InitializeComponent();
            this.folhaIndividual = folha;
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

        private void gridPontos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPontos.SelectedRows.Count > 0)
            {
                int rowIndex = gridPontos.SelectedRows[0].Index;
                mdlPontoEletronico ponto = folhaIndividual.pontos_eletronicos[rowIndex];

                txtData.Text = Convert.ToString(ponto.data);
                txtEntrada.Text = Convert.ToString(ponto.entrada);
                txtSaidaAlmoco.Text = Convert.ToString(ponto.saida_almoco);
                txtRetornoAlmoco.Text = Convert.ToString(ponto.retorno_almoco);
                txtSaida.Text = Convert.ToString(ponto.saida);
                txtJustificativa.Text = ponto.tipo_justificativa;
                txtDescricao.Text = ponto.descricao;

                TimeSpan tempoAlmoco = (TimeSpan)ponto.retorno_almoco - (TimeSpan)ponto.saida_almoco;
                TimeSpan horasTrabalhadas = (TimeSpan)ponto.saida - (TimeSpan)ponto.entrada;

                txtHorasTrabalhadas.Text = Convert.ToString(horasTrabalhadas);
                txtTempoAlmoco.Text = Convert.ToString(tempoAlmoco);
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada na DataGridView.");
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
