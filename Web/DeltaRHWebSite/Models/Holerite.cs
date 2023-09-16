using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_holerite")]
    public class Holerite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_holerite {  get; private set; }
        public decimal horas_trab { get; private set; }
        public decimal valor_desc_total { get; private set; }
        public decimal salario_liq { get; private set; }

        //Associacoes
        public int id_folhadepagamento { get; set; }
        [NotMapped]
        public virtual FolhaDePagamento? folhaDePagamento { get; set; }
        public int id_colaborador { get; set; }
        [NotMapped]
        public virtual Colaborador? colaborador { get; set; }

        public Holerite(decimal horas_trab, decimal valor_desc_total, decimal salario_liq, int id_folhadepagamento, int id_colaborador)
        {
            this.horas_trab = horas_trab;
            this.valor_desc_total = valor_desc_total;
            this.salario_liq = salario_liq;
            this.id_folhadepagamento = id_folhadepagamento;
            this.id_colaborador = id_colaborador;
        }
    }
}
