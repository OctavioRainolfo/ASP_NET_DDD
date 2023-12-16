using Microsoft.EntityFrameworkCore;
using Gerenciador_de_caixa.Models;

namespace Gerenciador_de_caixa.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PrestacaoDeServicos> PrestacaoDeServicos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}
