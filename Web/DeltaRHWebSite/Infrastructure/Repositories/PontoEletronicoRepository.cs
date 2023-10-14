using DeltaRH.API.Infrastructure.Repositories.Interfaces;
using DeltaRH.API.Models;
using DeltaRHWebSite.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace DeltaRH.API.Infrastructure.Repositories
{
    public class PontoEletronicoRepository : IPontoEletronicoRepository
    {
        private readonly ContextoConexao _contexto = new ContextoConexao();

        public void Add(PontoEletronico pontoEletronico)
        {
            _contexto.PontosEletronicos.Add(pontoEletronico);
            _contexto.SaveChanges();
        }

        public void Delete(PontoEletronico pontoEletronico)
        {
            _contexto.PontosEletronicos.Remove(pontoEletronico);
            _contexto.SaveChanges();
        }

        public PontoEletronico Get(int id)
        {
            return _contexto.PontosEletronicos.Single(entidade => entidade.id_pontoeletronico == id);
        }

        public List<PontoEletronico> GetAll()
        {
            return _contexto.PontosEletronicos.ToList();
        }

        public void Update(PontoEletronico pontoEletronico)
        {
            _contexto.PontosEletronicos.Update(pontoEletronico);
            _contexto.SaveChanges();
        }

        public PontoEletronico? GetPontoDoDia(string id)
        {
            PontoEletronico ponto = _contexto.PontosEletronicos.Where(entidade => entidade.id_colaborador == Convert.ToInt32(id) && entidade.data.Date == DateTime.Today).First();
            return ponto;
        }
    }
}
