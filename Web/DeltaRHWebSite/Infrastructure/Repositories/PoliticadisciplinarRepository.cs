using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories
{
    public class PoliticaDisciplinarRepository : IPoliticaDisciplinarRepository
    {

        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(PoliticaDisciplinar politicaDisciplinar)
        {
            _contexto.PoliticaDisciplinar.Add(politicaDisciplinar);
            _contexto.SaveChanges();
        }

        public void Delete(PoliticaDisciplinar politicaDisciplinar)
        {
            _contexto.PoliticaDisciplinar.Remove(politicaDisciplinar);
            _contexto.SaveChanges();
        }

        public PoliticaDisciplinar Get(int id)
        {
           return _contexto.PoliticaDisciplinar.Single(entidade => entidade.id_politicadisciplinar == id);
        }

        public List<PoliticaDisciplinar> GetAll()
        {
            return _contexto.PoliticaDisciplinar.ToList();
        }

        public void Update(PoliticaDisciplinar politicaDisciplinar)
        {
            _contexto.PoliticaDisciplinar.Update(politicaDisciplinar);
            _contexto.SaveChanges();
        }
    }
}
