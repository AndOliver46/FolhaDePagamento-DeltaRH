using DeltaRHWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization.Formatters.Binary;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;


public class LoginController : Controller
{

    private string consulta = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);

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
                    dadosLogin.status = rd.GetString(16);
                }
                rd.Close();

                if(dadosLogin != null) 
                { 
                    if (dadosLogin.senha.ToLower() == loginModel.senha.ToLower())
                    {
                            _contextAccessor.HttpContext.Session.SetString("cnpj", dadosLogin.cnpj);

                            if (dadosLogin.status.ToLower() != "Ativo".ToLower())
                            {
                                return RedirectToAction("LoginUsuario", "Login", new { statuserror = "true" });
                            }

                            _logger.LogInformation("Login feito");

                            return RedirectToAction("InfosEmpresa");
                    }
                }
            }
        }
        
        return RedirectToAction("LoginUsuario", "Login", new {error="true"});

    }

    public IActionResult InfosEmpresa()
    {
        string cnpj = _contextAccessor.HttpContext.Session.GetString("cnpj");
        EmpresaModel empresa = ConsultarEmpresa(cnpj);
        if(empresa != null)
        {
            empresa.Lista_folha = ConsultarFolhas(empresa.id_empresa);
            return View(empresa);
        }
        return RedirectToAction("LoginUsuario", "Login", new {sessaoInvalida="true"});

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
                    empresa.id_empresa = rd.GetInt32(0);
                    empresa.RazaoSocial = rd.GetString(2);
                    empresa.Logradouro = rd.GetString(6);
                    empresa.Numero = rd.GetString(7);
                    empresa.Cidade = rd.GetString(11);
                    empresa.Telefone = rd.GetString(13);
                    empresa.Telefone2 = rd.GetString(14);
                    empresa.id_missao = rd.GetInt32(22);
                    empresa.id_politica = rd.GetInt32(23);
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


    [HttpGet("/Login/DownloadDocumento/{id_folha}")]
    public IActionResult DownloadDocumento(int id_folha)
    {
        // Suponha que você já tenha uma conexão SQL configurada.
        using (SqlConnection conexaodb = new SqlConnection(consulta))
        {
            conexaodb.Open();

            // Crie uma consulta SQL para buscar o documento pelo ID.
            string query = "SELECT * FROM tbl_folhadepagamento WHERE id_folhadepagamento = @id_folha";
            using (SqlCommand cmd = new SqlCommand(query, conexaodb))
            {
                cmd.Parameters.AddWithValue("@id_folha", id_folha);

                // Execute a consulta.
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nome = "Folha de pagamento.xlsx";
                        byte[] documento = (byte[])reader[1];

                        // Defina o tipo de conteúdo.
                        string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                        // Retorne o arquivo como um FileResult.
                        return File(documento, contentType, nome);
                    }
                    else
                    {
                        return NotFound(); // Documento não encontrado.
                    }
                }
            }
        }
    }

    public List<FolhaModel> ConsultarFolhas(int id_empresa)
    {
        try
        {
            using (SqlConnection conexaodb = new SqlConnection(consulta))
            {
                conexaodb.Open();

                string query = "SELECT * FROM tbl_folhadepagamento WHERE id_empresa = @id_empresa";


                SqlCommand cmd = new SqlCommand(query, conexaodb);

                cmd.Parameters.AddWithValue("@id_empresa", id_empresa);

                SqlDataReader rd = cmd.ExecuteReader();

                List<FolhaModel>  Lista_folha = new List<FolhaModel>();
                while (rd.Read())
                {
                    FolhaModel folha = new FolhaModel();

                    folha.id_folha = rd.GetInt32(0);
                    folha.Periodo_inicio = rd.GetDateTime(6);
                    folha.Periodo_fim = rd.GetDateTime(7);
                    folha.Valor_final = rd.GetDecimal(2);
                    folha.Valor_desconto_final = rd.GetDecimal(3);
                    folha.Valor_liq_final = rd.GetDecimal(5);
                    folha.Status = rd.GetString(8);

                    if(folha.Status.ToLower() != "rascunho")
                    {
                        Lista_folha.Add(folha);
                    }
                }
                rd.Close();

                return Lista_folha;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [HttpGet]
    public IActionResult Sair()
    {
        if (_contextAccessor.HttpContext.Session != null)
        {
            _contextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("LoginUsuario");
        }
        else
        {
            _contextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("LoginUsuario");
        }

    }

    [HttpPost("/Login/AprovarFolha/{id_folha}")]
    public IActionResult AprovarFolha(int id_folha)
    {
        // Suponha que você já tenha uma conexão SQL configurada.
        using (SqlConnection conexaodb = new SqlConnection(consulta))
        {
            conexaodb.Open();

             string queryUp = "UPDATE tbl_folhadepagamento SET status_folha = @status_folha WHERE id_folhadepagamento = @id_folha";
             using (SqlCommand cmdUp = new SqlCommand(queryUp, conexaodb))
             {
                cmdUp.Parameters.AddWithValue("@status_folha", "Aprovado");
                cmdUp.Parameters.AddWithValue("@id_folha", id_folha);
                
                int updateStatus = cmdUp.ExecuteNonQuery();

                if (updateStatus > 0)
                {
                    return RedirectToAction("InfosEmpresa");
                }
             }
        }

        return RedirectToAction("InfosEmpresa", "Login", new { aproveerror = "true" });
    }


    [HttpPost("/Login/ReprovarFolha/{id_folha}")]
    public IActionResult ReprovarFolha(int id_folha)
    {
        // Suponha que você já tenha uma conexão SQL configurada.
        using (SqlConnection conexaodb = new SqlConnection(consulta))
        {
            conexaodb.Open();

            string queryUp = "UPDATE tbl_folhadepagamento SET status_folha = @status_folha WHERE id_folhadepagamento = @id_folha";
            using (SqlCommand cmdUp = new SqlCommand(queryUp, conexaodb))
            {
                cmdUp.Parameters.AddWithValue("@status_folha", "Reprovado");
                cmdUp.Parameters.AddWithValue("@id_folha", id_folha);

                int updateStatus = cmdUp.ExecuteNonQuery();

                if (updateStatus > 0)
                {
                    return RedirectToAction("InfosEmpresa");
                }
            }
        }

        return RedirectToAction("InfosEmpresa", "Login", new { aproveerror = "true" });
    }
}
