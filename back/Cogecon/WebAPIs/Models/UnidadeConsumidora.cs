namespace CogeconAPI.Models
{
    public class UnidadeConsumidora
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Concessionaria { get; set; }
        public bool Ativo { get; set; }
        public int CooperadoId { get; set; }
        public int EnderecoId { get; set; }
        public Cooperado Cooperado { get; set; }
        public Endereco Endereco { get; set; }
    }
}
