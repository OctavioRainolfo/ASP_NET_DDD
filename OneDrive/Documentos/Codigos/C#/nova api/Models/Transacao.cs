namespace Gerenciador_de_caixa.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public double Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // "entrada ou saida"
        public string? Descricao { get; set; }
    }

}
