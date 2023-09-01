using DeltaRHWebSite.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Controllers
{
    [ApiController]
    [Route("api/v1/colaborador")]
    public class ColaboradorController : ControllerBase
    { 

        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpPost]
        public IActionResult Add(ColaboradorDTO colaboradorDTO)
        {
            var colaborador = new Colaborador(
                colaboradorDTO.nome, colaboradorDTO.data_nascimento, colaboradorDTO.cpf,
                colaboradorDTO.tipo_contrato, colaboradorDTO.salario_base, 
                colaboradorDTO.carga_horaria, colaboradorDTO.senha);

            _colaboradorRepository.Add(colaborador);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get() { 
            var employees = _colaboradorRepository.GetAll();

            return Ok(); 
        }
    }
}
