using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages;

public class PizzaListModel : PageModel
{
    private readonly PizzaService _service;

    public IList<Pizza> PizzaList { get;set; } = default!;
    public Topping SelectedTopping { get;set; } = default!;

    public PizzaListModel(PizzaService service)
    {
        _service = service;
    }


    public void OnGet()
    {
        PizzaList = _service.GetPizzas();
        SelectedTopping = Topping.Bacon;
    }
}