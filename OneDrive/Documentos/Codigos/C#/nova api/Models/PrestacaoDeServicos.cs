namespace Gerenciador_de_caixa.Models
{
    public class PrestacaoDeServicos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCompra { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
    
    }
}
