namespace DeltaRHWebSite.Models.DTO
{
    public class HoleriteDTO
    {
        public decimal horas_trab { get; private set; }
        public decimal valor_desc_total { get; private set; }
        public decimal salario_liq { get; private set; }

        public HoleriteDTO(Holerite holerite)
        {
            this.horas_trab = holerite.horas_trab;
            this.valor_desc_total = holerite.valor_desc_total;
            this.salario_liq = holerite.salario_liq;
        }
    }
}
