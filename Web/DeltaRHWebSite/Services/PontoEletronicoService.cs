using DeltaRH.API.Infrastructure.Repositories.Interfaces;
using DeltaRH.API.Models;
using DeltaRH.API.Models.DTO;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;

namespace DeltaRH.API.Services
{
    public class PontoEletronicoService
    {
        private readonly IPontoEletronicoRepository _pontoEletronicoRepository;

        public PontoEletronicoService(IPontoEletronicoRepository pontoEletronicoRepository)
        {
            _pontoEletronicoRepository = pontoEletronicoRepository;
        }

        public PontoEletronicoDTO BuscarPontoDoDia(string? id_colaborador)
        {
            PontoEletronico? pontoEletronico;
            try
            {
                pontoEletronico = _pontoEletronicoRepository.GetPontoDoDia(id_colaborador);
            }catch (Exception ex) {
                pontoEletronico = new PontoEletronico(DateTime.Today, Convert.ToInt32(id_colaborador));
            }
            return new PontoEletronicoDTO(pontoEletronico);
        }
    }
}
