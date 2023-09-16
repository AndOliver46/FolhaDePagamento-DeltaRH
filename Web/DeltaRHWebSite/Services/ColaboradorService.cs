using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;
using Microsoft.AspNetCore.Mvc;

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
            var colaborador = new Colaborador(colaboradorDTO.nome, colaboradorDTO.data_nascimento, colaboradorDTO.cpf, colaboradorDTO.salario_bruto, colaboradorDTO.senha, colaboradorDTO.tipo_contrato, colaboradorDTO.carga_horaria, colaboradorDTO.logradouro, colaboradorDTO.numero, colaboradorDTO.complemento, colaboradorDTO.bairro, colaboradorDTO.cep, colaboradorDTO.cidade, colaboradorDTO.uf, colaboradorDTO.telefone, colaboradorDTO.telefone2, colaboradorDTO.email, colaboradorDTO.id_setor);
            _colaboradorRepository.Add(colaborador);
        }

        public bool ValidarLoginPorCPF(string cpf, string password)
        {
            Colaborador colaborador = _colaboradorRepository.FindByCPF(cpf);

            if (colaborador != null)
            {
                if (colaborador.senha == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Colaborador BuscarColaboradorPorCPF(string cpf)
        {

            Colaborador colaborador = _colaboradorRepository.FindByCPF(cpf);

            if (colaborador != null)
            {
                return colaborador;
            }

            throw new Exception("ERRO: O colaborador não foi encontrado");

        }
    }
}
