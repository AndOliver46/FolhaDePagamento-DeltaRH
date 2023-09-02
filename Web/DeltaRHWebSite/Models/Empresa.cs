using DeltaRHWebSite.Models.DTO;
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
        [NotMapped]
        public MissaoVisaoValores? missaovisaovalores { get; set; }
        public int id_politicadisciplinar { get; set; }
        [NotMapped]
        public PoliticaDisciplinar? politicadisciplinar { get; set; }
        [NotMapped]
        public ICollection<NormaRegra>? normaregras { get; set; }

        public Empresa(string? senha, string? razao_social, string? cnpj, string? logradouro, string? numero, string? complemento, string? bairro, string? cep, string? cidade, string? uf, string? telefone, string? telefone2, string? email, int id_missaovisaovalores, int id_politicadisciplinar)
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
            this.id_missaovisaovalores = id_missaovisaovalores;
            this.id_politicadisciplinar = id_politicadisciplinar;
        }

        public Empresa(EmpresaDTO empresaDTO)
        {
            this.senha = empresaDTO.senha;
            this.razao_social = empresaDTO.razao_social;
            this.cnpj = empresaDTO.cnpj;
            this.logradouro = empresaDTO.logradouro;
            this.numero = empresaDTO.numero;
            this.complemento = empresaDTO.complemento;
            this.bairro = empresaDTO.bairro;
            this.cep = empresaDTO.cep;
            this.cidade = empresaDTO.cidade;
            this.uf = empresaDTO.uf;
            this.telefone = empresaDTO.telefone;
            this.telefone2 = empresaDTO.telefone2;
            this.email = empresaDTO.email;
            this.id_missaovisaovalores = empresaDTO.id_missaovisaovalores;
            this.id_politicadisciplinar = empresaDTO.id_politicadisciplinar;
        }
    }
}
