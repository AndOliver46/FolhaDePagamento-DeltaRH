using DeltaRHWebSite.Infrastructure;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DeltaRHWebSite.Services
{
    public class EmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IPoliticaDisciplinarRepository _politicaDisciplinarRepository;
        private readonly IMissaoVisaoValoresRepository _missaoVisaoValoresRepository;

        public EmpresaService(IEmpresaRepository empresaRepository, IPoliticaDisciplinarRepository politicaDisciplinarRepository, IMissaoVisaoValoresRepository missaoVisaoValoresRepository)
        {
            this._empresaRepository = empresaRepository;
            this._politicaDisciplinarRepository = politicaDisciplinarRepository;
            this._missaoVisaoValoresRepository = missaoVisaoValoresRepository;
        }

        public void Add(EmpresaDTO empresaDTO)
        {
            var empresa = new Empresa(empresaDTO);
            var missaoVisaoValores = new MissaoVisaoValores(empresaDTO.missaovisaovalores);
            var politicaDisciplinar = new PoliticaDisciplinar(empresaDTO.politicadisciplinar);

            _politicaDisciplinarRepository.Add(politicaDisciplinar);
            _missaoVisaoValoresRepository.Add(missaoVisaoValores);

            empresa.id_politicadisciplinar = politicaDisciplinar.id_politicadisciplinar;
            empresa.id_missaovisaovalores = missaoVisaoValores.id_missaovisaovalores;

            _empresaRepository.Add(empresa);

        }
    }

}
