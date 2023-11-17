using System;
using System.ComponentModel;

namespace delta_modelo
{
    public class mdlPontoEletronico
    {
        [Browsable(false)]
        public int id_pontoeletronico { get; set; }

        [Browsable(true)]
        public DateTime data { get; set; }

        [Browsable(true)]
        public TimeSpan? entrada { get; set; }

        [Browsable(true)]
        public TimeSpan? saida_almoco { get; set; }

        [Browsable(true)]
        public TimeSpan? retorno_almoco { get; set; }

        [Browsable(true)]
        public TimeSpan? saida { get; set; }

        [Browsable(false)]
        public string tipo_justificativa { get; set; }

        [Browsable(false)]
        public string descricao { get; set; }

        [Browsable(false)]
        public Byte[] documento { get; set; }

        [Browsable(false)]
        public int id_colaborador { get; set; }

        [Browsable(false)]
        public bool abono { get; set; }
    }
}
