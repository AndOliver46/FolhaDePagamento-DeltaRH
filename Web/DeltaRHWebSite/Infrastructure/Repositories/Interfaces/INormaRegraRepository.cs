using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories.Interfaces
{
    public interface INormaRegraRepository
    {
        void Add(NormaRegra normaRegra);
        void Update(NormaRegra normaRegra);
        void Delete(NormaRegra normaRegra);
        NormaRegra Get(int id);
        List<NormaRegra> GetAll();


    }
}
