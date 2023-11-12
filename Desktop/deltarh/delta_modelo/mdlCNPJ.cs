using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace deltarh
{
    public class AtividadePincipal
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class AtividadeSecundaria
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class Billing
    {
        public bool free { get; set; }
        public bool database { get; set; }
    }

    public class Extra
    {

    }

    public class Qsa
    {
        public string nome { get; set; }
        public string qual { get; set; }
    }

    public class Empresa
    {
        public string abertura { get; set; }
        public string situacao { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string porte { get; set; }
        public string naturezaJuridica { get; set; }
        public List<Qsa> qsa { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string municipio { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string dataSituacao { get; set; }
        public string motivoSituacao { get; set; }
        public string cnpj { get; set; }
        public DateTime ultimaAtualizacao { get; set; }
        public string status { get; set; }
        public string fantasia { get; set; }
        public string complemento { get; set; }
        public string email { get; set; }
        public string efr { get; set; }
        public string situacaoEspecial { get; set; }
        public string dataSituacaoEspecial { get; set; }
        public List<AtividadePincipal> ativPrincipal { get; set; }
        public List<AtividadeSecundaria> ativSecundaria { get; set; }
        public string capitalSocial { get; set; }
        public Extra extra { get; set; }
        public Billing billing { get; set; }

        public static Empresa ObterCnpj(string cnpj)
        {
            Empresa empresa = null;

            try
            {
                string url = "https://www.receitaws.com.br/v1/cnpj/" + cnpj;
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);

                empresa = JsonConvert.DeserializeObject<Empresa>(json);

            }
            catch (Exception)
            {
                empresa = null;
            }


            return empresa;
        }
    }
}
