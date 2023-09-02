using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_normaregra")]
    public class NormaRegra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_normaregra { get; private set; }
        public string? tipo { get; private set; }
        public string? descricao { get; private set; }

        //Associacoes
        public int id_empresa { get; set; }
        public Empresa? empresa { get; set; }

        public NormaRegra(string? tipo, string? descricao, int id_empresa)
        {
            this.tipo = tipo;
            this.descricao = descricao;
            this.id_empresa = id_empresa;
        }
    }
}
