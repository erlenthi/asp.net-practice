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
