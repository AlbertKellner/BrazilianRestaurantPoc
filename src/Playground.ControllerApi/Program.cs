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
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Feijoada", Price = 20, ChefRecommendation = true },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Pão de Queijo", Price = 5, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Moqueca", Price = 22, ChefRecommendation = true },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Churrasco", Price = 25, ChefRecommendation = true },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Coxinha", Price = 4, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Acarajé", Price = 6, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Brigadeiro", Price = 3, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Pastel", Price = 5, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Tapioca", Price = 7, ChefRecommendation = false },
            new DataBaseDishItem { Id = Guid.NewGuid(), DishName = "Empadão", Price = 8, ChefRecommendation = false }
        };

    foreach (var dish in dishes)
    {
        DishInMemoryDatabase.Instance.AddDishItem(dish);
    }
}