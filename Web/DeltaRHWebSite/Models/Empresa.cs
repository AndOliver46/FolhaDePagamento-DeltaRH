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
        public int id_missaovisaovalores { get; set; }
        public MissaoVisaoValores? missaovisaovalores { get; set; }
        public int id_politicadisciplinar { get; set; }
        public PoliticaDisciplinar? politicadisciplinar { get; set; }
        public ICollection<NormaRegra>? normaregras { get; set; }

        public Empresa(string? senha, string? razao_social, string? cnpj, string? logradouro, string? numero, string? complemento, string? bairro, string? cep, string? cidade, string? uf, string? telefone, string? telefone2, string? email, MissaoVisaoValores missaovisaovalores, PoliticaDisciplinar politicadisciplinar)
        {
            this.senha = senha;
            this.razao_social = razao_social;
            this.cnpj = cnpj;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.uf = uf;
            this.telefone = telefone;
            this.telefone2 = telefone2;
            this.email = email;
            this.missaovisaovalores = missaovisaovalores;
            this.politicadisciplinar = politicadisciplinar;
        }
    }
}
