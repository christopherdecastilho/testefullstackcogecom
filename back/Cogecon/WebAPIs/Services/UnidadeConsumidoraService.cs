using CogeconAPI.Context;
using CogeconAPI.Interfaces;
using CogeconAPI.Models;

namespace CogeconAPI.Services
{
    public class UnidadeConsumidoraService : IUnidadeConsumidoraService
    {
        private readonly dbContext _dbContext;
        public UnidadeConsumidoraService(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(UnidadeConsumidora unidadeConsumidora)
        {
            try
            {
                _dbContext.UnidadesConsumidoras.Add(unidadeConsumidora);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(UnidadeConsumidora unidadeConsumidora)
        {
            try
            {
                _dbContext.UnidadesConsumidoras.Remove(unidadeConsumidora);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UnidadeConsumidora GetById(int id)
        {
            try
            {
                var UnidadeConsumidora = _dbContext.UnidadesConsumidoras.Find(id);

                return UnidadeConsumidora;
            }
            catch
            {
                throw;
            }
        }

        public void Update(UnidadeConsumidora unidadeConsumidora)
        {
            try
            {
                _dbContext.UnidadesConsumidoras.Update(unidadeConsumidora);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

    }
}
