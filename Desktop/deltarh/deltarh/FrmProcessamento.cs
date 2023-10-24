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
    public partial class FrmProcessamento : Form
    {
        public mdlFolhaDePagamento folha_de_pagamento;

        public FrmProcessamento(mdlFolhaDePagamento folhaDePagamento)
        {
            InitializeComponent();
            this.folha_de_pagamento = folhaDePagamento;
            PopularCampos();
        }

        public void PopularCampos()
        {
            txtId.Text = Convert.ToString(folha_de_pagamento.id_folha);
            txtEmpresa.Text = Convert.ToString(folha_de_pagamento.id_empresa);
            txtStatus.Text = folha_de_pagamento.status_folha;
            txtMesReferencia.Text = folha_de_pagamento.mes_referencia;
            txtInicio.Text = folha_de_pagamento.periodo_inicio.ToString("dd/MM/yyyy");
            txtTermino.Text = folha_de_pagamento.periodo_fim.ToString("dd/MM/yyyy");
            txtHorasTotais.Text = Convert.ToString(folha_de_pagamento.horas_trabalhadas);
            txtValorBruto.Text = Convert.ToString(folha_de_pagamento.valor_final);
            txtDescontos.Text = Convert.ToString(folha_de_pagamento.valor_desconto);
            txtValorLiquido.Text = Convert.ToString(folha_de_pagamento.salario_liquido);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtInicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProcessamento_Load(object sender, EventArgs e)
        {
        }
    }
}
