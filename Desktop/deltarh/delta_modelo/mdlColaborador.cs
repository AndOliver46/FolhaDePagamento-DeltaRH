using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_modelo
{
    public class mdlColaborador
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string cpf { get; set; }
        public string contrato { get; set; }
        public decimal salario { get; set; }
        public string senha { get; set; }
        public int cHoraria { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string fone1 { get; set; }
        public string fone2 { get; set; }
        public string email { get; set; }
        public int id_setor { get; set; }
        public string cargo { get; set; }
        public string status { get; set; }
        public int idEmpresa { get; set; }
        public TimeSpan horas_banco { get; set; }
        public mdlSetor setor { get; set; }
    }
}
