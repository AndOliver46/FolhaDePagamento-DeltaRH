using DeltaRHWebSite.Models.Enums;

namespace DeltaRHWebSite.Models.DTO
{
    public class ColaboradorDTO
    {
        public string? nome { get; private set; }
        public string? data_nascimento { get; private set; }
        public string? cpf { get; private set; }
        public TipoContrato tipo_contrato { get; private set; }
        public double salario_base { get; private set; }
        public int carga_horaria { get; private set; }
        public string? senha { get; private set; }
    }
}
