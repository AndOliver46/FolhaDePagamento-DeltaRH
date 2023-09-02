namespace DeltaRHWebSite.Models.Repositories
{
    public interface IEmpresaRepository
    {
        void Add(Empresa empresa);
        void Update(Empresa empresa);
        void Delete(Empresa empresa);
        Empresa Get(int id);
        List<Empresa> GetAll();


    }
}
