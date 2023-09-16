using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DeltaRH.WEB.Pages.Models;

namespace DeltaRH.WEB.Pages
{
    public class CadastroEmpresa : PageModel
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

            return RedirectToPage("ProximaPagina");
        }
    }
}
