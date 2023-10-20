using DeltaRHWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;

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
    public IActionResult SalvarEmpresa(EmpresaModel empresaModel)
    {
        var errors = ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .Select(x => new { x.Key, x.Value.Errors })
        .ToArray();
        if (ModelState.IsValid)
        {
            // Armazene a empresaModelJson na sessão
            string empresaModelJson = JsonConvert.SerializeObject(empresaModel);
            _contextAccessor.HttpContext.Session.SetString("EmpresaModel", empresaModelJson);

            return RedirectToAction("CadastroEndereco");
        }

        return RedirectToAction("CadastroEmpresa", "Error");
    }

    public IActionResult CadastroEndereco()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SalvarEndereco(EnderecoModel enderecoModel)
    {
        if (ModelState.IsValid)
        {
            string enderecoModelJson = JsonConvert.SerializeObject(enderecoModel);
            _contextAccessor.HttpContext.Session.SetString("EnderecoModel", enderecoModelJson);

            return RedirectToAction("CadastroValores");
        }

        return RedirectToAction("CadastroEndereco", "Error");
    }

    public IActionResult CadastroValores()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SalvarValores(ValoresModel valoresModel)
    {
        if (ModelState.IsValid)
        {
            string empresaModelJson = HttpContext.Session.GetString("EmpresaModel");
            EmpresaModel empresaModel = JsonConvert.DeserializeObject<EmpresaModel>(empresaModelJson);

            string enderecoModelJson = HttpContext.Session.GetString("EnderecoModel");
            EnderecoModel enderecoModel = JsonConvert.DeserializeObject<EnderecoModel>(enderecoModelJson);


            string _connectionString = "Data Source=localhost; Initial Catalog=BD_DELTA; User Id=admin; Password=admin; TrustServerCertificate=True";
            int IdMissaoVisaoValores;
            int IdPoliticaDisciplinar;

            using (SqlConnection conexaodb = new SqlConnection(_connectionString))
            {
                conexaodb.Open();


                string query = "INSERT INTO tbl_missaovisaovalores (descricao) VALUES (@descricao);SELECT CAST(scope_identity() AS int)";

                SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                cmd.Parameters.AddWithValue("@descricao", valoresModel.MissaoVisaoValores);

                IdMissaoVisaoValores = (int)cmd.ExecuteScalar();

            }

            using (SqlConnection conexaodb = new SqlConnection(_connectionString))
            {
                conexaodb.Open();

                string query = "INSERT INTO tbl_politicadisciplinar (descricao) VALUES (@descricao);SELECT CAST(scope_identity() AS int)";
                SqlCommand cmd = new SqlCommand(query, conexaodb); //instanciando

                cmd.Parameters.AddWithValue("@descricao", valoresModel.PoliticaDisciplinar);

                IdPoliticaDisciplinar = (int)cmd.ExecuteScalar();

            }

            using (SqlConnection conexaodb = new SqlConnection(_connectionString))
            {
                conexaodb.Open();

                string query = @"
        INSERT INTO tbl_empresa (
            senha, 
            razao_social, 
            cnpj, 
            nome_responsavel, 
            cpf_responsavel, 
            logradouro, 
            numero, 
            complemento, 
            bairro, 
            cep, 
            cidade, 
            uf, 
            telefone, 
            telefone2, 
            email, 
            status,
            id_missaovisaovalores, 
            id_politicadisciplinar
        ) VALUES (
            @senha, 
            @razao_social, 
            @cnpj, 
            @nome_responsavel, 
            @cpf_responsavel, 
            @logradouro, 
            @numero, 
            @complemento, 
            @bairro, 
            @cep, 
            @cidade, 
            @uf, 
            @telefone, 
            @telefone2, 
            @email, 
            @status,
            @id_missaovisaovalores, 
            @id_politicadisciplinar
        );
        SELECT CAST(scope_identity() AS int)";

                SqlCommand cmd = new SqlCommand(query, conexaodb);

                cmd.Parameters.AddWithValue("@senha", empresaModel.Senha);
                cmd.Parameters.AddWithValue("@razao_social", empresaModel.RazaoSocial);
                cmd.Parameters.AddWithValue("@cnpj", empresaModel.CNPJ);
                cmd.Parameters.AddWithValue("@nome_responsavel", empresaModel.Responsavel);
                cmd.Parameters.AddWithValue("@cpf_responsavel", empresaModel.CPFResponsavel);
                cmd.Parameters.AddWithValue("@logradouro", enderecoModel.Logradouro);
                cmd.Parameters.AddWithValue("@numero", enderecoModel.Numero);
                cmd.Parameters.AddWithValue("@complemento", enderecoModel.Complemento);
                cmd.Parameters.AddWithValue("@bairro", enderecoModel.Bairro);
                cmd.Parameters.AddWithValue("@cep", enderecoModel.CEP);
                cmd.Parameters.AddWithValue("@cidade", enderecoModel.Cidade);
                cmd.Parameters.AddWithValue("@uf", enderecoModel.Estado);
                cmd.Parameters.AddWithValue("@telefone", empresaModel.Telefone);
                cmd.Parameters.AddWithValue("@telefone2", empresaModel.Telefone2);
                cmd.Parameters.AddWithValue("@email", empresaModel.Email);
                cmd.Parameters.AddWithValue("@status", "Pendente");
                cmd.Parameters.AddWithValue("@id_missaovisaovalores", IdMissaoVisaoValores);
                cmd.Parameters.AddWithValue("@id_politicadisciplinar", IdPoliticaDisciplinar);

                int idInserido = (int)cmd.ExecuteScalar();
            }
        }

        return RedirectToAction("CadastroValores", "Error");
    }
}
