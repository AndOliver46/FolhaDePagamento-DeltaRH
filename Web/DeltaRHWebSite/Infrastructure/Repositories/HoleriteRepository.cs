using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Models;

namespace DeltaRHWebSite.Infrastructure.Repositories
{
    public class HoleriteRepository : IHoleriteRepository
    {
        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(Holerite holerite)
        {
            _contexto.Holerites.Add(holerite);
            _contexto.SaveChanges();
        }

        public void Delete(Holerite holerite)
        {
            _contexto.Holerites.Remove(holerite);
            _contexto.SaveChanges();
        }

        public Holerite Get(int id)
        {
            return _contexto.Holerites.Single(entidade => entidade.id_holerite == id);
        }

        public List<Holerite> GetAll()
        {
            return _contexto.Holerites.ToList();
        }

        public void Update(Holerite holerite)
        {
            _contexto.Holerites.Update(holerite);
            _contexto.SaveChanges();
        }

        public ICollection<Holerite> BuscarHoleritesDoColaborador(string? id)
        {
            return _contexto.Holerites.Where(entidade => entidade.id_colaborador == Convert.ToInt32(id)).ToList();
        }
    }
}
