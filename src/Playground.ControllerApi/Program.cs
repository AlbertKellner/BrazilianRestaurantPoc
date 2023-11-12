using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Shared.InMemoryDatabase;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.RegisterCustomWebApplicationBuilder();
builder.Services.RegisterCustomServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.RegisterCustomMiddleware();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

AddSampleDishes();

app.Run();

FlushLogsBeforeCloseApplication();

/// <summary>
/// Para garantir que os logs sejam descartados corretamente ao encerrar o aplicativo
/// </summary>
static void FlushLogsBeforeCloseApplication()
{
    Log.CloseAndFlush();
}

void AddSampleDishes()
{
    var dishes = new List<DataBaseDishItem>
    {
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Pão de Queijo", Price = 6, ChefRecommendation = true, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Coxinha de Frango", Price = 7, ChefRecommendation = false, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Pastel de Queijo", Price = 5, ChefRecommendation = false, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Bolinho de Bacalhau", Price = 8, ChefRecommendation = true, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Esfiha de Carne", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Starters" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Virado à Paulista", Price = 27, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Feijoada", Price = 35, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Bife à Parmegiana", Price = 30, ChefRecommendation = false, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Picanha na Chapa", Price = 40, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Frango à Passarinho", Price = 25, ChefRecommendation = false, Quantity = 1, Category = "À la carte" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Suco de Laranja", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Refrigerante", Price = 4, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Chá Mate Gelado", Price = 5, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Caipirinha", Price = 12, ChefRecommendation = true, Quantity = 1, Category = "Beverages" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Brigadeiro", Price = 3, ChefRecommendation = true, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Beijinho", Price = 3, ChefRecommendation = false, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Quindim", Price = 5, ChefRecommendation = true, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Pudim de Leite", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Bolo de Rolo", Price = 7, ChefRecommendation = true, Quantity = 1, Category = "Desserts" }
    };

    foreach (var dish in dishes)
    {
        DishInMemoryDatabase.Instance.AddDishItem(dish);
    }
}