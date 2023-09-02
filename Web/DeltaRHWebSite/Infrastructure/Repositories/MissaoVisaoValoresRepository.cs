using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories
{
    public class MissaoVisaoValoresRepository : IMissaoVisaoValoresRepository
    {

        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(MissaoVisaoValores missaoVisaoValores)
        {
            _contexto.MissaoVisaoValores.Add(missaoVisaoValores);
            _contexto.SaveChanges();
        }

        public void Delete(MissaoVisaoValores missaoVisaoValores)
        {
            _contexto.MissaoVisaoValores.Remove(missaoVisaoValores);
            _contexto.SaveChanges();
        }

        public MissaoVisaoValores Get(int id)
        {
           return _contexto.MissaoVisaoValores.Single(entidade => entidade.id_missaovisaovalores == id);
        }

        public List<MissaoVisaoValores> GetAll()
        {
            return _contexto.MissaoVisaoValores.ToList();
        }

        public void Update(MissaoVisaoValores missaoVisaoValores)
        {
            _contexto.MissaoVisaoValores.Update(missaoVisaoValores);
            _contexto.SaveChanges();
        }
    }
}
