using DeltaRH.API.Models.DTO;
using DeltaRH.API.Services;
using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeltaRHWebSite.Controllers.Mobile
{
    [Authorize("AuthorizedUsers")]
    [ApiController]
    [Route("api/v1/mobile")]
    public class MobileController : ControllerBase
    {

        private readonly ColaboradorService _colaboradorService;
        private readonly HoleriteService _holeriteService;
        private readonly PontoEletronicoService _pontoEletronicoService;

        public MobileController(ColaboradorService _colaboradorService, HoleriteService _holeriteService, PontoEletronicoService _pontoEletronicoService)
        {
            this._colaboradorService = _colaboradorService;
            this._holeriteService = _holeriteService;
            this._pontoEletronicoService = _pontoEletronicoService;
        }

        [HttpGet("carregar-dados-usuario")]
        public IActionResult BuscarDadosColaborador()
        {
            string cpf = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            ColaboradorDTO colaboradorDTO = _colaboradorService.BuscarColaboradorPorCPF(cpf);
     
            return Ok(colaboradorDTO);
        }

        [HttpGet("carregar-registro-ponto")]
        public IActionResult BuscarPonto()
        {
            string id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            PontoEletronicoDTO pontoEletronicoDTO = _pontoEletronicoService.BuscarPontoDoDia(id);

            return Ok(pontoEletronicoDTO);
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
