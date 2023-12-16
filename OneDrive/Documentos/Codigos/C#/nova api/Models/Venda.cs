namespace Gerenciador_de_caixa.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ProdutosId { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double Total { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
