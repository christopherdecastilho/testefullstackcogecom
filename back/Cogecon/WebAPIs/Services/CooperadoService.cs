using CogeconAPI.Context;
using CogeconAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using CogeconAPI.Interfaces;

namespace CogeconAPI.Services
{
    public class CooperadoService : ICooperadoService
    {
        private readonly dbContext _dbContext;
        public CooperadoService(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Cooperado cooperado)
        {
            try
            {
                _dbContext.Cooperados.Add(cooperado);

                if (cooperado.UnidadesConsumidoras != null)
                {
                    foreach (var unidadeConsumidora in cooperado.UnidadesConsumidoras)
                    {
                        if (unidadeConsumidora.Endereco != null)
                        {
                            _dbContext.Enderecos.Add(unidadeConsumidora.Endereco);
                        }
                        _dbContext.UnidadesConsumidoras.Add(unidadeConsumidora);
                    }
                }

                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Cooperado cooperado)
        {
            try
            {
                _dbContext.Cooperados.Remove(cooperado);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Cooperado GetById(int id)
        {
            try
            {
                var cooperado = _dbContext.Cooperados.Find(id);

                return cooperado;
            }
            catch
            {
                throw;
            }
        }

        public void Update(Cooperado cooperado)
        {
            try
            {
                _dbContext.Cooperados.Update(cooperado);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
