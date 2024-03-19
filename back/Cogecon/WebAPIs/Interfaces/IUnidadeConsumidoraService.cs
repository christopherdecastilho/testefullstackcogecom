using CogeconAPI.Models;

namespace CogeconAPI.Interfaces
{
    public interface IUnidadeConsumidoraService
    {
        void Add(UnidadeConsumidora unidadeConsumidora);
        UnidadeConsumidora GetById(int id);
        void Update(UnidadeConsumidora unidadeConsumidora);
        void Delete(UnidadeConsumidora unidadeConsumidora);
    }
}
