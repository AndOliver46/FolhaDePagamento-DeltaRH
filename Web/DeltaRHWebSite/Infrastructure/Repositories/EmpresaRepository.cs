using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(Empresa empresa)
        {
            _contexto.Empresas.Add(empresa);
            _contexto.SaveChanges();
        }

        public void Delete(Empresa empresa)
        {
            _contexto.Empresas.Remove(empresa);
            _contexto.SaveChanges();
        }

        public Empresa Get(int id)
        {
           return _contexto.Empresas.Single(entidade => entidade.id_empresa == id);
        }

        public List<Empresa> GetAll()
        {
            return _contexto.Empresas.ToList();
        }

        public void Update(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
