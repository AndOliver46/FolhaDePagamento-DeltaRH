using DeltaRHWebSite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRH.API.Models
{
    [Table("tbl_pontoeletronico")]
    public class PontoEletronico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pontoeletronico { get; private set; }
        public DateTime data { get; private set; }
        public TimeSpan? entrada { get; set; }
        public TimeSpan? saida_almoco { get; set; }

        public TimeSpan? retorno_almoco { get; set; }

        public TimeSpan? saida { get; set; }
        public String? tipo_justificativa { get; private set; }
        public String? descricao { get; private set; }
        public Byte[]? documento { get; private set; }

        //Associacoes
        public int id_colaborador { get; set; }
        [NotMapped]
        public virtual Colaborador? colaborador { get; set; }

        public PontoEletronico(DateTime data, int id_colaborador)
        {
            this.data = data;
            this.id_colaborador = id_colaborador;
        }

        public PontoEletronico(DateTime data, TimeSpan? entrada, TimeSpan? saida_almoco, TimeSpan? retorno_almoco, TimeSpan? saida, string? tipo_justificativa, string? descricao, byte[]? documento, int id_colaborador)
        {
            this.data = data;
            this.entrada = entrada;
            this.saida_almoco = saida_almoco;
            this.retorno_almoco = retorno_almoco;
            this.saida = saida;
            this.tipo_justificativa = tipo_justificativa;
            this.descricao = descricao;
            this.documento = documento;
            this.id_colaborador = id_colaborador;
        }
    }
}
