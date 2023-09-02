using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using DeltaRHWebSite.Models.DTO;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_politicadisciplinar")]
    public class PoliticaDisciplinar
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_politicadisciplinar { get; private set; }
        public string? descricao { get; private set; }
        public string? advertencia { get; private set; }
        public string? dispensa { get; private set; }
        public string? suspensao { get; private set; }

        public PoliticaDisciplinar(string? descricao, string? advertencia, string? dispensa, string? suspensao)
        {
            this.descricao = descricao;
            this.advertencia = advertencia;
            this.dispensa = dispensa;
            this.suspensao = suspensao;
        }

        public PoliticaDisciplinar(PoliticaDisciplinarDTO politicaDisciplinarDTO)
        {
            this.descricao = politicaDisciplinarDTO.descricao;
            this.advertencia = politicaDisciplinarDTO.advertencia;
            this.dispensa = politicaDisciplinarDTO.dispensa;
            this.suspensao = politicaDisciplinarDTO.suspensao;
        }
    }
}
