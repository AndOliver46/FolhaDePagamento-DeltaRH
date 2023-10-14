using DeltaRHWebSite.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_missaovisaovalores")]
    public class MissaoVisaoValores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_missaovisaovalores { get; private set; }
        public string? descricao { get; private set; }
        public string? visao_futuro { get; private set; }
        public string? produtividade { get; private set; }
        public string? sustentabilidade { get; private set; }

        public MissaoVisaoValores(string? descricao, string? visao_futuro, string? produtividade, string? sustentabilidade)
        {
            this.descricao = descricao;
            this.visao_futuro = visao_futuro;
            this.produtividade = produtividade;
            this.sustentabilidade = sustentabilidade;
        }

        public MissaoVisaoValores(MissaoVisaoValoresDTO missaoVisaoValoresDTO)
        {
            this.descricao = missaoVisaoValoresDTO.descricao;
            this.visao_futuro = missaoVisaoValoresDTO.visao_futuro;
            this.produtividade = missaoVisaoValoresDTO.produtividade;
            this.sustentabilidade = missaoVisaoValoresDTO.sustentabilidade;
        }
    }
}
