using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRH.API.Models.DTO
{
    public class PontoEletronicoDTO
    {
        public int id_pontoeletronico { get; private set; }
        public DateTime? data { get; private set; }
        public TimeSpan? entrada { get; private set; }
        public TimeSpan? saida_almoco { get; private set; }

        public TimeSpan? retorno_almoco { get; private set; }

        public TimeSpan? saida { get; private set; }
        public String? tipo_justificativa { get; private set; }
        public String? descricao { get; private set; }
        public Byte[]? documento { get; private set; }

        //Associacoes
        public int id_colaborador { get; set; }


        public PontoEletronicoDTO() { }

        public PontoEletronicoDTO(int id_pontoeletronico, DateTime? data, TimeSpan? entrada, TimeSpan? saida_almoco, TimeSpan? retorno_almoco, TimeSpan? saida, string? tipo_justificativa, string? descricao, byte[]? documento, int id_colaborador)
        {
            this.id_pontoeletronico = id_pontoeletronico;
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

        public PontoEletronicoDTO(PontoEletronico pontoEletronico)
        {
            this.id_pontoeletronico = pontoEletronico.id_pontoeletronico;
            this.data = pontoEletronico.data;
            this.entrada = pontoEletronico.entrada;
            this.saida_almoco = pontoEletronico.saida_almoco;
            this.retorno_almoco = pontoEletronico.retorno_almoco;
            this.saida = pontoEletronico.saida;
            this.tipo_justificativa = pontoEletronico.tipo_justificativa;
            this.descricao = pontoEletronico.descricao;
            this.documento = pontoEletronico.documento;
            this.id_colaborador = pontoEletronico.id_colaborador;
        }
    }
}
