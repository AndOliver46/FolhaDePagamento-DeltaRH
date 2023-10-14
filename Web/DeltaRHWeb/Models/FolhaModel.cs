namespace DeltaRHWeb.Models
{
    public class FolhaModel
    {
        public int id_folha { get; set; }
        public Byte[]? Folha_arquivo { get; set; }
        public decimal Valor_final { get; set; }
        public decimal Valor_desconto_final { get; set; }
        public decimal Valor_liq_final { get; set; }
        public DateTime Periodo_inicio { get; set; }
        public DateTime Periodo_fim { get; set; }
        public string Status { get; set; }
    }
}
