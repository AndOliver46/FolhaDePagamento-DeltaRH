using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_empresa")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_empresa { get; private set; }
        public string? senha { get; private set; }

        public string? razao_social { get; private set; }

        public string? cnpj { get; private set; }

        public string? logradouro { get; private set; }

        public string? numero { get; private set; }

        public string? complemento { get; private set; }

        public string? bairro { get; private set; }

        public string? cep { get; private set; }

        public string? cidade { get; private set; }

        public string? uf { get; private set; }
        public string? telefone { get; private set; }
        public string? telefone2 { get; private set; }
        public string? email { get; private set; }

        //Associacoes
        //public MissaoVisaoValores missaovisaovalores { get; private set; }
        //public PoliticaDisciplinar politicadisciplinar { get; private set; }


    }
}
