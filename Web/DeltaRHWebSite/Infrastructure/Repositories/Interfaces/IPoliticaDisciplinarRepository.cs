using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories.Interfaces
{
    public interface IPoliticaDisciplinarRepository
    {
        void Add(PoliticaDisciplinar politicaDisciplinar);
        void Update(PoliticaDisciplinar politicaDisciplinar);
        void Delete(PoliticaDisciplinar politicaDisciplinar);
        PoliticaDisciplinar Get(int id);
        List<PoliticaDisciplinar> GetAll();


    }
}
