using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class NewSqlPizzaListModel : PageModel
    {
        private readonly SqlPizzaContext _context;

        public IList<Pizza> PizzaList { get; set; } = default!;

        [BindProperty]
        public Pizza NewPizza { get; set; } = new Pizza();

        public NewSqlPizzaListModel(SqlPizzaContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            PizzaList = await _context.Pizzas.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PizzaList = await _context.Pizzas.ToListAsync();
                return Page();
            }

            _context.Pizzas.Add(NewPizza);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
