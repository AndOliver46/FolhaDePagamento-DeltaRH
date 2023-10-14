using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories.Interfaces
{
    public interface IHoleriteRepository
    {
        void Add(Holerite holerite);
        void Update(Holerite holerite);
        void Delete(Holerite holerite);
        Holerite Get(int id);
        List<Holerite> GetAll();
        ICollection<Holerite> BuscarHoleritesDoColaborador(string? id);
    }
}
