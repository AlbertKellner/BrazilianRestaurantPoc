using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;

namespace Playground.Application.Shared.InMemoryDatabase
{
    public sealed class TableReservationInMemoryDatabase
    {
        private static readonly TableReservationInMemoryDatabase instance = new TableReservationInMemoryDatabase();
        private readonly List<DataBaseTableReservationItem> TableReservationItems;

        static TableReservationInMemoryDatabase()
        {
        }

        private TableReservationInMemoryDatabase()
        {
            TableReservationItems = new List<DataBaseTableReservationItem>();
        }

        public static TableReservationInMemoryDatabase Instance
        {
            get
            {
                return instance;
            }
        }

        // Create
        public void AddTableReservationItem(DataBaseTableReservationItem item)
        {
            TableReservationItems.Add(item);
        }

        // Read
        public List<DataBaseTableReservationItem> GetTableReservationItems()
        {
            return TableReservationItems;
        }

        public DataBaseTableReservationItem GetTableReservationtemById(Guid id)
        {
            return TableReservationItems.FirstOrDefault(item => item.Id == id) ?? new();
        }

        // Update
        public void UpdateTableReservationItem(DataBaseTableReservationItem updatedItem)
        {
            var existingItem = TableReservationItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.DishName = updatedItem.DishName;
                existingItem.Description = updatedItem.Description;
                existingItem.Price = updatedItem.Price;
                existingItem.Category = updatedItem.Category;
                existingItem.CookingTime = updatedItem.CookingTime;
                existingItem.ServingSize = updatedItem.ServingSize;
                existingItem.Ingredients = updatedItem.Ingredients;
                existingItem.Allergens = updatedItem.Allergens;
                existingItem.SpicinessLevel = updatedItem.SpicinessLevel;
                existingItem.IsAvailable = updatedItem.IsAvailable;
                existingItem.ImageUrl = updatedItem.ImageUrl;
                existingItem.ChefRecommendation = updatedItem.ChefRecommendation;
                existingItem.Special = updatedItem.Special;
            }
        }

        // Delete
        public void RemoveTableReservationItem(Guid id)
        {
            var itemToRemove = TableReservationItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                TableReservationItems.Remove(itemToRemove);
            }
        }
    }

}
