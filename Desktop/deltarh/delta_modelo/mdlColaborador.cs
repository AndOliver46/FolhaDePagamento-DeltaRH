using System;
using System.ComponentModel;

namespace delta_modelo
{
    public class mdlColaborador
    {
        [Browsable(false)]
        public int id { get; set; }
        [DisplayName("Nome Colaborador")]
        public string nome { get; set; }
        [Browsable(false)]
        public DateTime nascimento { get; set; }
        [DisplayName("CPF")]
        public string cpf { get; set; }
        [Browsable(false)]
        public string contrato { get; set; }
        [Browsable(false)]
        public decimal salario { get; set; }
        [Browsable(false)]
        public string senha { get; set; }
        [Browsable(false)]
        public int cHoraria { get; set; }
        [Browsable(false)]
        public string logradouro { get; set; }
        [Browsable(false)]
        public string numero { get; set; }
        [Browsable(false)]
        public string complemento { get; set; }
        [Browsable(false)]
        public string bairro { get; set; }
        [Browsable(false)]
        public string cep { get; set; }
        [Browsable(false)]
        public string cidade { get; set; }
        [Browsable(false)]
        public string uf { get; set; }
        [Browsable(false)]
        public string fone1 { get; set; }
        [Browsable(false)]
        public string fone2 { get; set; }
        [Browsable(false)]
        public string email { get; set; }
        [Browsable(false)]
        public int id_setor { get; set; }
        [Browsable(false)]
        public string cargo { get; set; }
        [Browsable(false)]
        public string status { get; set; }
        [Browsable(false)]
        public int idEmpresa { get; set; }
        [Browsable(false)]
        public decimal horas_banco { get; set; }
        [Browsable(false)]
        public DateTime data_admissao { get; set; }
        [DisplayName("Vencimento")]
        public DateTime vencimento_ferias { get; set; }
        [DisplayName("Limite")]
        public DateTime limite_ferias { get; set; }
        [Browsable(false)]
        public mdlSetor setor { get; set; }
    }
}
