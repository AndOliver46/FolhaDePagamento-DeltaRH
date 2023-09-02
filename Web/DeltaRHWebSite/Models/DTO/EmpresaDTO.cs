namespace DeltaRHWebSite.Models.DTO
{
    public class EmpresaDTO
    {
        public string? senha { get; set; }

        public string? razao_social { get; set; }

        public string? cnpj { get; set; }

        public string? logradouro { get; set; }

        public string? numero { get; set; }

        public string? complemento { get; set; }

        public string? bairro { get; set; }

        public string? cep { get; set; }

        public string? cidade { get; set; }

        public string? uf { get; set; }
        public string? telefone { get; set; }
        public string? telefone2 { get; set; }
        public string? email { get; set; }

        public int id_missaovisaovalores { get; set; }
        public MissaoVisaoValoresDTO? missaovisaovalores { get; set; }
        public int id_politicadisciplinar { get; set; }
        public PoliticaDisciplinarDTO? politicadisciplinar { get; set; }
        public ICollection<NormaRegraDTO>? normaregras { get; set; }
    }
}
