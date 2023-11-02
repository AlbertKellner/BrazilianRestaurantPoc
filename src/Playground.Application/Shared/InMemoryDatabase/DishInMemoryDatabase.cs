namespace Playground.Application.Shared.InMemoryDatabase
{
    public class DataBaseDishItem
    {
        public Guid Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>(); // Assuming your database can store this as JSON or via a related table
        public List<string> Allergens { get; set; } = new List<string>(); // Assuming your database can store this as JSON or via a related table
        public string SpicinessLevel { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool ChefRecommendation { get; set; }
        public bool Special { get; set; }
    }


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
                existingItem.IsAvailable = updatedItem.IsAvailable;
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
