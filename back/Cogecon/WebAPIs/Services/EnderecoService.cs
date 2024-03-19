using CogeconAPI.Context;
using CogeconAPI.Interfaces;
using CogeconAPI.Models;

namespace CogeconAPI.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly dbContext _dbContext;
        public EnderecoService(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Endereco endereco)
        {
            try
            {
                _dbContext.Enderecos.Add(endereco);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Endereco endereco)
        {
            try
            {
                _dbContext.Enderecos.Remove(endereco);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Endereco GetById(int id)
        {
            try
            {
                var endereco = _dbContext.Enderecos.Find(id);

                return endereco;
            }
            catch
            {
                throw;
            }
        }

        public void Update(Endereco endereco)
        {
            try
            {
                _dbContext.Enderecos.Update(endereco);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
