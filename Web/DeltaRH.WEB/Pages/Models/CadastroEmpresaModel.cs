using System.ComponentModel.DataAnnotations;

namespace DeltaRH.WEB.Pages.Models
{
    public class CadastroEmpresaModel
    {
        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        [MinLength(12)]
        public string CNPJ { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Responsavel { get; set; }

        [Required]
        public string CPFResponsavel { get; set; }

        public string Telefone { get; set; }

        [Required]
        public string Telefone2 { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        [MinLength(12)]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
