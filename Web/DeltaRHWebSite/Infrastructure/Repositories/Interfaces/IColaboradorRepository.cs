using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories.Interfaces
{
    public interface IColaboradorRepository
    {
        void Add(Colaborador colaborador);
        void Update(Colaborador colaborador);
        void Delete(Colaborador colaborador);
        Colaborador Get(int id);
        List<Colaborador> GetAll();

    }
}
