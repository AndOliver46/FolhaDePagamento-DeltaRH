using DeltaRHWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class CadastroController : Controller
{
    private readonly ILogger<CadastroController> _logger;
    
    private readonly IHttpContextAccessor _contextAccessor;

    public CadastroController(ILogger<CadastroController> logger, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
    }

    public IActionResult CadastroEmpresa()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SalvarEmpresa(EmpresaModel model)
    {
        if (ModelState.IsValid)
        {
            // Armazene a empresaModelJson na sessão
            string empresaModelJson = JsonConvert.SerializeObject(model);
            _contextAccessor.HttpContext.Session.SetString("EmpresaModel", empresaModelJson);

            return RedirectToAction("CadastroEndereco");
        }

        return RedirectToAction("CadastroEmpresa", "Error");
    }

    public IActionResult CadastroEndereco()
    {
        // Recupere a empresaModel da sessão, se existir
        string empresaModelJson = HttpContext.Session.GetString("EmpresaModel");
        EmpresaModel empresaModel = JsonConvert.DeserializeObject<EmpresaModel>(empresaModelJson);
        _logger.LogInformation(empresaModel.ToString());
        return View();
    }
}
