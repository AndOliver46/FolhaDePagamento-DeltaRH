using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_folhadepagamento")]
    public class FolhaDePagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_folhadepagamento { get; private set; }
        public decimal valor_folhafinal { get; private set; }
        public decimal valor_desc_total { get; private set; }
        public TimeSpan horas_trab { get; private set; }
        public decimal salario_liq { get; private set; }
        public DateTime? periodo_inicio { get; private set; }
        public DateTime? periodo_fim { get; private set; }

        //Associacoes
        public int id_empresa { get; set; }
        public virtual Empresa? empresa { get; set; }

        public FolhaDePagamento(decimal valor_folhafinal, decimal valor_desc_total, TimeSpan horas_trab, decimal salario_liq, DateTime? periodo_inicio, DateTime? periodo_fim, int id_empresa, Empresa? empresa)
        {
            this.valor_folhafinal = valor_folhafinal;
            this.valor_desc_total = valor_desc_total;
            this.horas_trab = horas_trab;
            this.salario_liq = salario_liq;
            this.periodo_inicio = periodo_inicio;
            this.periodo_fim = periodo_fim;
            this.id_empresa = id_empresa;
            this.empresa = empresa;
        }
    }
}
