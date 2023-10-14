using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models.DTO;
using DeltaRHWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using DeltaRH.API.Models.DTO;

namespace DeltaRHWebSite.Services
{
    public class ColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public bool ValidarLoginPorCPF(string cpf, string password)
        {
            try
            {
                Colaborador colaborador = _colaboradorRepository.FindByCPF(cpf);

                if (colaborador != null)
                {
                    if (colaborador.senha == password)
                    {
                        return true;
                    }
                }
            }catch(Exception ex)
            {
                return false;
            }
            return false;
        }

        public ColaboradorDTO BuscarColaboradorPorCPF(string cpf)
        {

            Colaborador colaborador = _colaboradorRepository.FindByCPF(cpf);
            
            if (colaborador != null)
            {
                ColaboradorDTO colaboradorDTO = new ColaboradorDTO(colaborador);
                return colaboradorDTO;
            }

            throw new Exception("ERRO: O colaborador não foi encontrado");

        }
    }
}
