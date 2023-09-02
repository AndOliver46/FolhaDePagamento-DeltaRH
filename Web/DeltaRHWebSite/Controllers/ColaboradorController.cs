using DeltaRHWebSite.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

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
            var colaborador = new Colaborador(colaboradorDTO.nome, colaboradorDTO.data_nascimento, colaboradorDTO.cpf, colaboradorDTO.salario_bruto, colaboradorDTO.senha, colaboradorDTO.tipo_contrato, colaboradorDTO.carga_horaria, colaboradorDTO.logradouro, colaboradorDTO.numero, colaboradorDTO.complemento, colaboradorDTO.bairro, colaboradorDTO.cep, colaboradorDTO.cidade, colaboradorDTO.uf, colaboradorDTO.telefone, colaboradorDTO.telefone2, colaboradorDTO.email);
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
