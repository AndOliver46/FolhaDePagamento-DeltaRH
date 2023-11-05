using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_holerite")]
    public class Holerite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_holerite { get; set; }
        public string nome_empresa { get; set; }
        public string cnpj_empresa { get; set; }
        public DateTime periodo_inicio { get; set; }
        public DateTime periodo_fim { get; set; }
        public string nome_colaborador { get; set; }
        public string cargo_colaborador { get; set; }
        public decimal horas_trab { get; set; }
        public decimal porcentagem_vt { get; set; }
        public decimal porcentagem_vr { get; set; }
        public decimal porcentagem_assis_odonto { get; set; }
        public decimal porcentagem_assis_medica { get; set; }
        public decimal porcentagem_adiantamento { get; set; }
        public decimal horas_extras { get; set; }
        public decimal salario_base { get; set; }
        public decimal total_vencimentos { get; set; }
        public decimal total_descontos { get; set; }
        public decimal salario_liq { get; set; }
        public string mes_ano_ref { get; set; }

        //Associacoes
        public int id_folhadepagamento { get; set; }
        [NotMapped]
        public virtual FolhaDePagamento? folhaDePagamento { get; set; }
        public int id_colaborador { get; set; }
        [NotMapped]
        public virtual Colaborador? colaborador { get; set; }
    }
}
