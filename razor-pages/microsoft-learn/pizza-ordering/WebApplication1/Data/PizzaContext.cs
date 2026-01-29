using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Pizza>? Pizzas { get; set; }
    }
}
