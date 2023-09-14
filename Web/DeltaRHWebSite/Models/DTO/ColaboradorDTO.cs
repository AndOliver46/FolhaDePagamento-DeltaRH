using DeltaRHWebSite.Models.Enums;

namespace DeltaRHWebSite.Models.DTO
{
    public class ColaboradorDTO
    {
        public string? nome { get; set; }
        public DateTime? data_nascimento { get; set; }
        public string? cpf { get; set; }
        public decimal salario_bruto { get; set; }
        public string? senha { get; set; }
        public string? tipo_contrato { get; set; }
        public int carga_horaria { get; set; }
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
        public int id_setor { get; set; }
        public Setor setor { get; set; }
    }
}
