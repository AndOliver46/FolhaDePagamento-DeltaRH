using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Services
{
    public class ColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public void Add(ColaboradorDTO colaboradorDTO)
        {
            var colaborador = new Colaborador(colaboradorDTO.nome, colaboradorDTO.data_nascimento, colaboradorDTO.cpf, colaboradorDTO.salario_bruto, colaboradorDTO.senha, colaboradorDTO.tipo_contrato, colaboradorDTO.carga_horaria, colaboradorDTO.logradouro, colaboradorDTO.numero, colaboradorDTO.complemento, colaboradorDTO.bairro, colaboradorDTO.cep, colaboradorDTO.cidade, colaboradorDTO.uf, colaboradorDTO.telefone, colaboradorDTO.telefone2, colaboradorDTO.email);
            _colaboradorRepository.Add(colaborador);
        } 
        
    }
}
