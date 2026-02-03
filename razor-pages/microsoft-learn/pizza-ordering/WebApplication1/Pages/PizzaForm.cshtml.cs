using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;


namespace WebApplication1.Pages
{
    public class PizzaFormModel : PageModel
    {
         private readonly PizzaService _service;

        [BindProperty]
        public Pizza NewPizza { get; set; } = new Pizza();

        public IList<Pizza> PizzaList { get;set; } = default!;

        public PizzaFormModel(PizzaService service)
        {
            _service = service;
        }
        public void OnGet()
        {
                PizzaList = _service.GetPizzas();
        }
       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);
            Console.WriteLine("Pizza added: " + NewPizza.Name);
            return RedirectToPage("/PizzaForm");
        }

    }
}
