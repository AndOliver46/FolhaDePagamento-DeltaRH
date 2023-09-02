using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Services;

namespace DeltaRHWebSite.Controllers
{
    [ApiController]
    [Route("api/v1/empresa")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public IActionResult Add(EmpresaDTO empresaDTO)
        {
            _empresaService.Add(empresaDTO);

            return Ok();
        }
    }
}