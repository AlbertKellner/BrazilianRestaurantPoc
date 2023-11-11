using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;

namespace Playground.Application.Shared.InMemoryDatabase
{
    public sealed class DishInMemoryDatabase
    {
        private static readonly DishInMemoryDatabase instance = new DishInMemoryDatabase();
        private readonly List<DataBaseDishItem> DishItems;

        static DishInMemoryDatabase()
        {
        }

        private DishInMemoryDatabase()
        {
            DishItems = new List<DataBaseDishItem>();
        }

        public static DishInMemoryDatabase Instance
        {
            get
            {
                return instance;
            }
        }

        // Create
        public void AddDishItem(DataBaseDishItem item)
        {
            DishItems.Add(item);
        }

        // Read
        public List<DataBaseDishItem> GetDishItems()
        {
            return DishItems;
        }

        public DataBaseDishItem GetDishtemById(Guid id)
        {
            return DishItems.FirstOrDefault(item => item.Id == id) ?? new();
        }

        // Update
        public void UpdateDishItem(DataBaseDishItem updatedItem)
        {
            var existingItem = DishItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.DishName = updatedItem.DishName;
                existingItem.Price = updatedItem.Price;
                existingItem.ChefRecommendation = updatedItem.ChefRecommendation;
                existingItem.Quantity = updatedItem.Quantity;
            }
        }

        // Delete
        public void RemoveDishItem(Guid id)
        {
            var itemToRemove = DishItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                DishItems.Remove(itemToRemove);
            }
        }
    }

}
