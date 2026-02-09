using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class NewPizzaListModel : PageModel
    {
        private readonly PizzaService _service;

        public IList<Pizza> PizzaList { get; set; } = default!;
    
        public decimal MinPizzaPrice { get; private set; } = default;
        public decimal MaxPizzaPrice { get; private set; } = default;

        public NewPizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
            var pizzaPrices = PizzaList.Select(p => p.Price).ToList();
            MinPizzaPrice = pizzaPrices.Min();
            MaxPizzaPrice = pizzaPrices.Max();
        }
    }
}
