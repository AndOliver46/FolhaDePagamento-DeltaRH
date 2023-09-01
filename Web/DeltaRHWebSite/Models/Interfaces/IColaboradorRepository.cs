namespace DeltaRHWebSite.Models.Repositories
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
