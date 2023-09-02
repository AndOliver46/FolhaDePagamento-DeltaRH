using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories
{
    public class NormaRegraRepository : INormaRegraRepository
    {

        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(NormaRegra normaRegra)
        {
            _contexto.NormaRegra.Add(normaRegra);
            _contexto.SaveChanges();
        }

        public void Delete(NormaRegra normaRegra)
        {
            _contexto.NormaRegra.Remove(normaRegra);
            _contexto.SaveChanges();
        }

        public NormaRegra Get(int id)
        {
           return _contexto.NormaRegra.Single(entidade => entidade.id_normaregra == id);
        }

        public List<NormaRegra> GetAll()
        {
            return _contexto.NormaRegra.ToList();
        }

        public void Update(NormaRegra normaRegra)
        {
            _contexto.NormaRegra.Update(normaRegra);
            _contexto.SaveChanges();
        }
    }
}
