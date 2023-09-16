using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeltaRH.WEB.Pages.Models
{
    public class CadastroEmpresaController : PageModel
    {
        [BindProperty]
        public CadastroEmpresaModel Empresa { get; set; }

        public void OnGet()
        {
            CadastroEmpresaModel cadastroEmpresaModel = new CadastroEmpresaModel();
            Empresa = cadastroEmpresaModel;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Processar os dados do formulário aqui
            // Por exemplo, salvar no banco de dados
            Console.Write(Empresa.ToString());

            return StatusCode(200);
        }
    }
}
