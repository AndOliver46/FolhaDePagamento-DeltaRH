using System.ComponentModel.DataAnnotations;

namespace DeltaRHWeb.Models
{
    public class EmpresaModel
    {

        public int id_empresa { get; set; }
        [Required(ErrorMessage = "Razão Social é obrigatória")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Responsável é obrigatório")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "CPF do Responsável é obrigatório")]
        public string CPFResponsavel { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório")]
        public string Telefone2 { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Senha { get; set; }

        public int id_missao { get; set; }

        public int id_politica { get; set; }

        public string descricao_missao { get; set; }

        public string descricao_politica { get; set; }
        public List<FolhaModel> Lista_folha { get; set; }

        public EmpresaModel() { }

        public EmpresaModel(EmpresaModel model)
        {
            RazaoSocial = model.RazaoSocial;
            CNPJ = model.CNPJ;
            Email = model.Email;
            Responsavel = model.Responsavel;
            CPFResponsavel = model.CPFResponsavel;
            Telefone = model.Telefone;
            Telefone2 = model.Telefone2;
            Senha = model.Senha;
        }

        public override string? ToString()
        {
            return RazaoSocial + CNPJ;
        }
    }
}
