using DeltaRHWebSite.Models;
using DeltaRHWebSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeltaRHWebSite.Controllers.Mobile
{
    [Authorize]
    [ApiController]
    [Route("api/v1/mobile")]
    public class MobileController : ControllerBase
    {

        private readonly ColaboradorService _colaboradorService;

        public MobileController(ColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet("carregar-dados-usuario")]
        public IActionResult GetUserInfo()
        {
            string cpf = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            Colaborador colaborador = _colaboradorService.BuscarColaboradorPorCPF(cpf);
     
            return Ok(colaborador);
        }
    }
}
