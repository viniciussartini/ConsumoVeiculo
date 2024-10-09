using ConsumoVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumoVeiculo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
