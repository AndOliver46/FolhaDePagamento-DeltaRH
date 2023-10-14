using Microsoft.AspNetCore.Mvc;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Services;

namespace DeltaRHWebSite.Controllers
{
    [ApiController]
    [Route("api/v1/colaborador")]
    public class ColaboradorController : ControllerBase
    { 

        private readonly ColaboradorService _colaboradorService;

        public ColaboradorController(ColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public IActionResult Get() {
       
            return Ok(); 
        }
    }
}
