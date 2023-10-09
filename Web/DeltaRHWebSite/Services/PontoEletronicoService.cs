using DeltaRH.API.Infrastructure.Repositories.Interfaces;
using DeltaRH.API.Models;
using DeltaRH.API.Models.DTO;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using Newtonsoft.Json.Linq;

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
            PontoEletronico pontoEletronico = BuscarPontoOuCriar(id_colaborador);
            PontoEletronicoDTO pontoEletronicoDTO = new PontoEletronicoDTO(pontoEletronico);
            return pontoEletronicoDTO;
        }

        public PontoEletronicoDTO SalvarPonto(string? id_colaborador, string tipo_ponto)
        {
            PontoEletronico pontoEletronico = BuscarPontoOuCriar(id_colaborador);

            if(tipo_ponto == "entrada")
            {
                pontoEletronico.entrada = DateTime.Now.TimeOfDay;
            }else if (tipo_ponto == "pausa")
            {
                pontoEletronico.saida_almoco = DateTime.Now.TimeOfDay;
            }
            else if (tipo_ponto == "retorno")
            {
                pontoEletronico.retorno_almoco = DateTime.Now.TimeOfDay;
            }
            else if (tipo_ponto == "saida")
            {
                pontoEletronico.saida = DateTime.Now.TimeOfDay;
            }

            _pontoEletronicoRepository.Update(pontoEletronico);

            return new PontoEletronicoDTO(pontoEletronico);
        }

        private PontoEletronico BuscarPontoOuCriar(string? id_colaborador)
        {
            PontoEletronico? pontoEletronico;
            try
            {
                pontoEletronico = _pontoEletronicoRepository.GetPontoDoDia(id_colaborador);
            }
            catch (Exception ex)
            {
                pontoEletronico = new PontoEletronico(DateTime.Today, Convert.ToInt32(id_colaborador));
                _pontoEletronicoRepository.Add(pontoEletronico);
            }
            return pontoEletronico;
        }
    }
}
