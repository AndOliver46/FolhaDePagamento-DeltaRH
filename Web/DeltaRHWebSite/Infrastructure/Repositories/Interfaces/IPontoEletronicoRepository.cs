using DeltaRH.API.Models;
using DeltaRHWebSite.Models;

namespace DeltaRH.API.Infrastructure.Repositories.Interfaces
{
    public interface IPontoEletronicoRepository
    {
        void Add(PontoEletronico pontoEletronico);
        void Update(PontoEletronico pontoEletronico);
        void Delete(PontoEletronico pontoEletronico);
        PontoEletronico Get(int id);
        List<PontoEletronico> GetAll();
        PontoEletronico GetPontoDoDia(string id);
    }
}
