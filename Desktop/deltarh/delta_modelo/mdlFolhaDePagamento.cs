using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_modelo
{
    public class mdlFolhaDePagamento
    {
        public int id_folha { get; set; }
        public byte[] relatorio { get; set; }
        public decimal salario_base { get; set; }
        public decimal valor_desconto { get; set; }
        public decimal horas_trabalhadas { get; set; }
        public decimal salario_liquido { get; set; }
        public DateTime periodo_inicio { get; set; }
        public DateTime periodo_fim { get; set; }
        public string status_folha { get; set; }
        public int id_empresa { get; set; }
        public string mes_referencia { get; set; }
    }
}
