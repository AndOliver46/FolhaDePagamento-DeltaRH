using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_setor")]
    public class Setor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_setor { get; private set; }
        public string? nome_setor { get; private set; }

        //Associacoes
        public int id_empresa { get; set; }
        [NotMapped]
        public Empresa? empresa { get; set; }
    }
}
