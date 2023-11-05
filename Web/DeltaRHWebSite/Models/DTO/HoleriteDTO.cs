namespace DeltaRHWebSite.Models.DTO
{
    public class HoleriteDTO
    {
        public int id_holerite { get; set; }
        public string nome_empresa { get; set; }
        public string cnpj_empresa { get; set; }
        public DateTime periodo_inicio { get; set; }
        public DateTime periodo_fim { get; set; }
        public int id_folhadepagamento { get; set; }
        public int id_colaborador { get; set; }
        public string nome_colaborador { get; set; }
        public string cargo_colaborador { get; set; }
        public decimal horas_trab { get; set; }
        public decimal porcentagem_vt { get; set; }
        public decimal porcentagem_vr { get; set; }
        public decimal porcentagem_assis_odonto { get; set; }
        public decimal porcentagem_assis_medica { get; set; }
        public decimal porcentagem_adiantamento { get; set; }
        public decimal horas_extras { get; set; }
        public decimal salario_base { get; set; }
        public decimal total_vencimentos { get; set; }
        public decimal total_descontos { get; set; }
        public decimal salario_liq { get; set; }
        public string mes_ano_ref { get; set; }

        public HoleriteDTO(Holerite model)
        {
            id_holerite = model.id_holerite;
            nome_empresa = model.nome_empresa;
            cnpj_empresa = model.cnpj_empresa;
            periodo_inicio = model.periodo_inicio;
            periodo_fim = model.periodo_fim;
            id_folhadepagamento = model.id_folhadepagamento;
            id_colaborador = model.id_colaborador;
            nome_colaborador = model.nome_colaborador;
            cargo_colaborador = model.cargo_colaborador;
            horas_trab = model.horas_trab;
            porcentagem_vt = model.porcentagem_vt;
            porcentagem_vr = model.porcentagem_vr;
            porcentagem_assis_odonto = model.porcentagem_assis_odonto;
            porcentagem_assis_medica = model.porcentagem_assis_medica;
            porcentagem_adiantamento = model.porcentagem_adiantamento;
            horas_extras = model.horas_extras;
            salario_base = model.salario_base;
            total_vencimentos = model.total_vencimentos;
            total_descontos = model.total_descontos;
            salario_liq = model.salario_liq;
            mes_ano_ref = model.mes_ano_ref;
        }
    }
}
