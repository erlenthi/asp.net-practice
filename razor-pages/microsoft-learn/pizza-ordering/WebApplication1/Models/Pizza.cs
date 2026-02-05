using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
    
    public List<Topping> Toppings { get; set; } = new List<Topping>();

    
}

public enum PizzaSize { Small, Medium, Large }

public enum Topping 
{ 
    Pepperoni, 
    Mushrooms, 
    Onions, 
    Sausage, 
    Bacon, 
    ExtraCheese, 
    BlackOlives, 
    GreenPeppers 
}
