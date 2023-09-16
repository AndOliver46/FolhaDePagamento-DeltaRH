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
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
