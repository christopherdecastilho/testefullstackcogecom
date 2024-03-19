using CogeconAPI.Models;

namespace CogeconAPI.Interfaces
{
    public interface IEnderecoService
    {
        void Add(Endereco endereco);
        Endereco GetById(int id);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);
    }
}
