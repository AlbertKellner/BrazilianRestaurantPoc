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
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Cheese Roll", Price = 6, ChefRecommendation = true, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Chicken Nugget", Price = 7, ChefRecommendation = false, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Cheese Pastry", Price = 5, ChefRecommendation = false, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Codfish Fritter", Price = 8, ChefRecommendation = true, Quantity = 1, Category = "Starters" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Minced Meat Pie", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Starters" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Picanha burger", Price = 27, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Feijoada", Price = 35, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Parmesan Steak", Price = 30, ChefRecommendation = false, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Grilled Sirloin Steak", Price = 40, ChefRecommendation = true, Quantity = 1, Category = "À la carte" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Fried Chicken Bites", Price = 25, ChefRecommendation = false, Quantity = 1, Category = "À la carte" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Orange Juice", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Soda", Price = 4, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Iced Tea", Price = 5, ChefRecommendation = false, Quantity = 1, Category = "Beverages" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Caipirinha", Price = 12, ChefRecommendation = true, Quantity = 1, Category = "Beverages" },

        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Chocolate Fudge", Price = 3, ChefRecommendation = true, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Coconut Ice", Price = 3, ChefRecommendation = false, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Custard Square", Price = 5, ChefRecommendation = true, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Caramel Pudding", Price = 6, ChefRecommendation = false, Quantity = 1, Category = "Desserts" },
        new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Swiss Roll Cake", Price = 7, ChefRecommendation = true, Quantity = 1, Category = "Desserts" }
    };


    foreach (var dish in dishes)
    {
        DishInMemoryDatabase.Instance.AddDishItem(dish);
    }
}