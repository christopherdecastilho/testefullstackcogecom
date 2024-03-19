namespace CogeconAPI.Models
{
    public class Cooperado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public ICollection<UnidadeConsumidora> UnidadesConsumidoras { get; set; }
    }
}