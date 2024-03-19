using CogeconAPI.Models;

namespace CogeconAPI.Interfaces
{
    public interface ICooperadoService
    {
        void Add(Cooperado cooperado);
        Cooperado GetById(int id);
        void Update(Cooperado cooperado);
        void Delete(Cooperado cooperado);
    }
}
