using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Services;

namespace DeltaRHWebSite.Controllers.Mobile
{
    [Route("api/v1/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ColaboradorService _colaboradorService;

        public AutenticacaoController(IConfiguration configuration, ColaboradorService colaboradorService)
        {
            _configuration = configuration;
            _colaboradorService = colaboradorService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CredenciaisLoginDTO credentials)
        {
            if (credentials == null)
            {
                return BadRequest("Credenciais inválidas.");
            }

            // Verificar as credenciais (substitua isso pela sua lógica de autenticação real)
            if (IsValidUser(credentials.CPF, credentials.Password, credentials.isLogged))
            {
                ColaboradorDTO colaboradorDTO = _colaboradorService.BuscarColaboradorPorCPF(credentials.CPF);
                // Credenciais válidas, gerar um token JWT
                var token = GenerateJwtToken(colaboradorDTO.cpf, colaboradorDTO.id_colaborador);

                return Ok(new { Token = token, message = "Login realizado com sucesso", error = false });
            }

            return Unauthorized();
        }

        private bool IsValidUser(string cpf, string password, Boolean isLogged)
        {
            return _colaboradorService.ValidarLoginPorCPF(cpf, password) && isLogged;
        }

        private string GenerateJwtToken(string cpf, int id)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, cpf), new Claim(ClaimTypes.NameIdentifier, Convert.ToString(id)) },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
