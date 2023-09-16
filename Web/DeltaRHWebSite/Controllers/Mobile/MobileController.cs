using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.DTO;
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
        private readonly HoleriteService _holeriteService;

        public MobileController(ColaboradorService _colaboradorService, HoleriteService _holeriteService)
        {
            this._colaboradorService = _colaboradorService;
            this._holeriteService = _holeriteService;
        }

        [HttpGet("carregar-dados-usuario")]
        public IActionResult BuscarDadosColaborador()
        {
            string cpf = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            ColaboradorDTO colaboradorDTO = _colaboradorService.BuscarColaboradorPorCPF(cpf);
     
            return Ok(colaboradorDTO);
        }

        [HttpGet("carregar-holerites")]
        public IActionResult BuscarHolerites()
        {
            string id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ICollection<HoleriteDTO> holerites = _holeriteService.BuscarHoleritesColaborador(id);

            return Ok(holerites);
        }
    }
}
