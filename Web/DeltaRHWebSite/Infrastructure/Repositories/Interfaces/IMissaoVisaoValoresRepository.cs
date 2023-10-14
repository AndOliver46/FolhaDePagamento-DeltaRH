using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories.Interfaces
{
    public interface IMissaoVisaoValoresRepository
    {
        void Add(MissaoVisaoValores missaoVisaoValores);
        void Update(MissaoVisaoValores missaoVisaoValores);
        void Delete(MissaoVisaoValores missaoVisaoValores);
        MissaoVisaoValores Get(int id);
        List<MissaoVisaoValores> GetAll();


    }
}
