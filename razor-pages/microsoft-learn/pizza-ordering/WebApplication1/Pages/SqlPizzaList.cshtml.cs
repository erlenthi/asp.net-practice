using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class SqlPizzaListModel : PageModel
    {
        private readonly SqlPizzaContext _context;

        public IList<Pizza> PizzaList { get; set; } = default!;

        public SqlPizzaListModel(SqlPizzaContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            PizzaList = await _context.Pizzas.ToListAsync();
        }
    }
}
