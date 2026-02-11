using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class SqlPizzaContext : DbContext
    {
        public SqlPizzaContext(DbContextOptions<SqlPizzaContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Pizza> Pizzas { get; set; } = default!;
    }
}
