namespace DeltaRHWebSite.Models.DTO
{
    public class NormaRegraDTO
    {
        public string? tipo { get; set; }
        public string? descricao { get; set; }

        //Associacoes
        public int id_empresa { get; set; }
        public EmpresaDTO? empresa { get; set; }
    }
}
