using DeltaRHWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

public class LoginController : Controller
{

    public string consulta = @"Data Source=localhost; Initial Catalog=BD_DELTA; User Id=admin; Password=admin; TrustServerCertificate=True";

    private readonly ILogger<LoginController> _logger;

    private readonly IHttpContextAccessor _contextAccessor;

    public LoginController(ILogger<LoginController> logger, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
    }

    public IActionResult LoginUsuario()
    {
        return View();
    }
        
    [HttpPost]
    public IActionResult FazerLogin([FromForm]LoginModel loginModel)
    {
        if (ModelState.IsValid)
        {

            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {

            
                conexaodb.Open();

                string query = "SELECT * FROM tbl_empresa WHERE cnpj = @cnpj";


                SqlCommand cmd = new SqlCommand(query, conexaodb);

                cmd.Parameters.AddWithValue("@cnpj", loginModel.cnpj);

                SqlDataReader rd = cmd.ExecuteReader();

                LoginModel dadosLogin = null;
                while (rd.Read())
                {
                    dadosLogin = new LoginModel();
                    dadosLogin.senha = rd.GetString(1);
                    dadosLogin.cnpj = rd.GetString(3);
                }
                rd.Close();


                if (dadosLogin.senha == loginModel.senha)
                {
                    _logger.LogInformation("Login feito");

                    _contextAccessor.HttpContext.Session.SetString("cnpj", dadosLogin.cnpj);

                    return RedirectToAction("InfosEmpresa");
                }
            }
        }
        
        return RedirectToAction("LoginUsuario", "Login", new {error="true"});

    }

    public IActionResult InfosEmpresa()
    {
        string cnpj = _contextAccessor.HttpContext.Session.GetString("cnpj");
        EmpresaModel empresa = ConsultarEmpresa(cnpj);
        return View(empresa);

    }

    public EmpresaModel ConsultarEmpresa(string cnpj)
    {
        try
        {
            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                conexaodb.Open();

                string query = "SELECT * FROM tbl_empresa WHERE cnpj = @cnpj";


                SqlCommand cmd = new SqlCommand(query, conexaodb);

                cmd.Parameters.AddWithValue("@cnpj", cnpj);

                SqlDataReader rd = cmd.ExecuteReader();

                EmpresaModel empresa = null;
                while (rd.Read())
                {
                    empresa = new EmpresaModel();
                    empresa.RazaoSocial = rd.GetString(2);
                    empresa.Logradouro = rd.GetString(6);
                    empresa.Numero = rd.GetString(7);
                    empresa.Cidade = rd.GetString(11);
                    empresa.Telefone = rd.GetString(13);
                    empresa.Telefone2 = rd.GetString(14);
                    empresa.id_missao = rd.GetInt32(17);
                    empresa.id_politica = rd.GetInt32(18);
                }
                rd.Close();

                if (empresa != null)
                {
                    string query_m = "SELECT descricao FROM tbl_missaovisaovalores WHERE id_missaovisaovalores = @id_missao";

                    SqlCommand cmd_m = new SqlCommand(query_m, conexaodb);

                    cmd_m.Parameters.AddWithValue("@id_missao", empresa.id_missao);

                    SqlDataReader rd_m = cmd_m.ExecuteReader();

                    while (rd_m.Read())
                    {
                        empresa.descricao_missao = rd_m.GetString(0);
                    }
                    rd_m.Close();

                    string query_p = "SELECT descricao FROM tbl_politicadisciplinar WHERE id_politicadisciplinar = @id_politica";

                    SqlCommand cmd_p = new SqlCommand(query_p, conexaodb);

                    cmd_p.Parameters.AddWithValue("@id_politica", empresa.id_politica);

                    SqlDataReader rd_p = cmd_p.ExecuteReader();

                    while (rd_p.Read())
                    {
                        empresa.descricao_politica = rd_p.GetString(0);
                    }
                    rd_p.Close();
                }

                return empresa;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }


}
