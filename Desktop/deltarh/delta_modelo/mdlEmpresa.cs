using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_modelo
{
    public class mdlEmpresa
    {
        public int id { get; set; }
        public string senha { get; set; }
        public string razao { get; set; }
        public string cnpj { get; set; }
        public string responsavel { get; set; }
        public string cpf { get; set; }
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
        public string status { get; set; }
        public decimal vt { get; set; }
        public decimal vr { get; set; }
        public decimal assMedica { get; set; }
        public decimal odonto { get; set; }
        public decimal gym { get; set; }
        public int id_missao { get; set; }
        public int id_politica {  get; set; }
        public mdlMissao missao { get; set; }
        public mdlPolitica politica { get; set; }

    }
}
