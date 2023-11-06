using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_modelo
{
    public class mdlPontoEletronico
    {
        public int id_pontoeletronico { get; set; }
        public DateTime data { get; set; }
        public TimeSpan? entrada { get; set; }
        public TimeSpan? saida_almoco { get; set; }

        public TimeSpan? retorno_almoco { get; set; }

        public TimeSpan? saida { get; set; }
        public string tipo_justificativa { get; set; }
        public string descricao { get; set; }
        public Byte[] documento { get; set; }
        public int id_colaborador { get; set; }
        public bool abono {  get; set; }
    }
}
