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

var app = builder.Build();

// Seed the database with sample pizzas
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaContext>();

    if (!context.Pizzas.Any())
    {
        context.Pizzas.AddRange(
            new Pizza
            {
                Name = "Margherita",
                Size = PizzaSize.Medium,
                IsGlutenFree = false,
                Price = 12.99M
            },
            new Pizza
            {
                Name = "Pepperoni",
                Size = PizzaSize.Large,
                IsGlutenFree = false,
                Price = 15.99M
            },
            new Pizza
            {
                Name = "Veggie Delight",
                Size = PizzaSize.Medium,
                IsGlutenFree = true,
                Price = 13.99M
            }
            ,
                        new Pizza
                        {
                            Name = "Hawaiian",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 14.99M
                        },
                        new Pizza
                        {
                            Name = "BBQ Chicken",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = false,
                            Price = 16.99M
                        },
                        new Pizza
                        {
                            Name = "Meat Lovers",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 17.99M
                        },
                        new Pizza
                        {
                            Name = "Four Cheese",
                            Size = PizzaSize.Small,
                            IsGlutenFree = false,
                            Price = 11.99M
                        },
                        new Pizza
                        {
                            Name = "Supreme",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 18.99M
                        },
                        new Pizza
                        {
                            Name = "Mediterranean",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = true,
                            Price = 15.49M
                        },
                        new Pizza
                        {
                            Name = "Buffalo Chicken",
                            Size = PizzaSize.Medium,
                            IsGlutenFree = false,
                            Price = 16.49M
                        },
                        new Pizza
                        {
                            Name = "Mushroom Truffle",
                            Size = PizzaSize.Small,
                            IsGlutenFree = true,
                            Price = 14.49M
                        },
                        new Pizza
                        {
                            Name = "Spicy Italian",
                            Size = PizzaSize.Large,
                            IsGlutenFree = false,
                            Price = 16.99M
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
