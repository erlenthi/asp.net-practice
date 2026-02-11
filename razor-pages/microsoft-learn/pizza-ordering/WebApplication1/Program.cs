using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Services;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<PizzaService>();

// Add DbContext with SQL Server (for development, using in-memory)
builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseInMemoryDatabase("PizzaDb"));

// Add SQL Server DbContext
builder.Services.AddDbContext<SqlPizzaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlPizzaConnection")));

var app = builder.Build();

// Seed the database with sample pizzas
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaContext>();

    if (context.Pizzas != null && !context.Pizzas.Any())
    {
        context.Pizzas.AddRange(
            new Pizza
            {
                Name = "Margherita",
                Size = PizzaSize.Medium,
                IsGlutenFree = false,
                Price = 12.99M,
                Toppings = new List<Topping> { Topping.ExtraCheese }
            },
            new Pizza
            {
                Name = "Pepperoni",
                Size = PizzaSize.Large,
                IsGlutenFree = false,
                Price = 15.99M,
                Toppings = new List<Topping> { Topping.Pepperoni, Topping.ExtraCheese }
            },
            new Pizza
            {
                Name = "Veggie Delight",
                Size = PizzaSize.Medium,
                IsGlutenFree = true,
                Price = 13.99M,
                Toppings = new List<Topping> { Topping.Mushrooms, Topping.Onions, Topping.GreenPeppers, Topping.BlackOlives }
            }
            ,
                        new Pizza
                        {
                            Name = "Hawaiian",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 14.99M,
                            Toppings = new List<Topping> { Topping.Bacon }
                        },
                        new Pizza
                        {
                            Name = "BBQ Chicken",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = false,
                            Price = 16.99M,
                            Toppings = new List<Topping> { Topping.Onions, Topping.Bacon }
                        },
                        new Pizza
                        {
                            Name = "Meat Lovers",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 17.99M,
                            Toppings = new List<Topping> { Topping.Pepperoni, Topping.Sausage, Topping.Bacon }
                        },
                        new Pizza
                        {
                            Name = "Four Cheese",
                            Size = PizzaSize.Small,
                            IsGlutenFree = false,
                            Price = 11.99M,
                            Toppings = new List<Topping> { Topping.ExtraCheese }
                        },
                        new Pizza
                        {
                            Name = "Supreme",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 18.99M,
                            Toppings = new List<Topping> { Topping.Pepperoni, Topping.Sausage, Topping.Mushrooms, Topping.Onions, Topping.GreenPeppers, Topping.BlackOlives }
                        },
                        new Pizza
                        {
                            Name = "Mediterranean",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = true,
                            Price = 15.49M,
                            Toppings = new List<Topping> { Topping.BlackOlives, Topping.Onions }
                        },
                        new Pizza
                        {
                            Name = "Buffalo Chicken",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = false,
                            Price = 16.49M,
                            Toppings = new List<Topping> { Topping.Onions, Topping.ExtraCheese }
                        },
                        new Pizza
                        {
                            Name = "Mushroom Truffle",
                            Size = PizzaSize.Small,
                            IsGlutenFree = true,
                            Price = 14.49M,
                            Toppings = new List<Topping> { Topping.Mushrooms, Topping.ExtraCheese }
                        },
                        new Pizza
                        {
                            Name = "Spicy Italian",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 16.99M,
                            Toppings = new List<Topping> { Topping.Pepperoni, Topping.Sausage, Topping.GreenPeppers }
                        },
                        new Pizza
                        {
                            Name = "Garden Fresh",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = true,
                            Price = 13.49M
                        }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
