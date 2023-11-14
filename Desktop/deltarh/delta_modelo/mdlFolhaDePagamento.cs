using System;
using System.ComponentModel;

namespace delta_modelo
{
    public class mdlFolhaDePagamento
    {
        [Browsable(false)]
        public int id_folha { get; set; }
        [Browsable(false)]
        public byte[] relatorio { get; set; }
        [Browsable(false)]
        public decimal salario_base { get; set; }
        [Browsable(false)]
        public decimal valor_desconto { get; set; }
        [Browsable(false)]
        public decimal horas_trabalhadas { get; set; }
        [Browsable(false)]
        public decimal salario_liquido { get; set; }

        [DisplayName("ID Empresa")]
        public int id_empresa { get; set; }
        [DisplayName("Mes/Ano Ref")]
        public string mes_referencia { get; set; }
        [DisplayName("Periodo Inicio")]
        public DateTime periodo_inicio { get; set; }
        [DisplayName("Periodo Fim")]
        public DateTime periodo_fim { get; set; }
        [DisplayName("Status")]
        public string status_folha { get; set; }
    }
}
