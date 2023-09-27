using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;
using DeltaRHWebSite.Models.DTO;
using System.Collections.Generic;

namespace DeltaRHWebSite.Services
{
    public class HoleriteService
    {
        private readonly IHoleriteRepository _holeriteRepository;

        public HoleriteService(IHoleriteRepository _holeriteRepository)
        {
            this._holeriteRepository = _holeriteRepository;
        }

        public ICollection<HoleriteDTO> BuscarHoleritesColaborador(string? id)
        {

            //ICollection<Holerite> holerites = _holeriteRepository.BuscarHoleritesDoColaborador(id);
            //ICollection<HoleriteDTO> holeritesDTO = holerites.Select(holerite => new HoleriteDTO(holerite)).ToList();


            ICollection<Holerite> holerites = _holeriteRepository.BuscarHoleritesDoColaborador(id);
            ICollection<HoleriteDTO> holeritesDTO = holerites.Select(holerite => new HoleriteDTO(holerite)).ToList();


            return holeritesDTO;
        }
    }
}
