namespace Playground.Application.Shared.InMemoryDatabase
{
    public class DataBaseDigitalMenuItem
    {
        public Guid Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }

    public sealed class DigitalMenuInMemoryDatabase
    {
        private static readonly DigitalMenuInMemoryDatabase instance = new DigitalMenuInMemoryDatabase();
        private readonly List<DataBaseDigitalMenuItem> digitalMenuItems;

        static DigitalMenuInMemoryDatabase()
        {
        }

        private DigitalMenuInMemoryDatabase()
        {
            digitalMenuItems = new List<DataBaseDigitalMenuItem>();
        }

        public static DigitalMenuInMemoryDatabase Instance
        {
            get
            {
                return instance;
            }
        }

        // Create
        public void AddDigitalMenuItem(DataBaseDigitalMenuItem item)
        {
            digitalMenuItems.Add(item);
        }

        // Read
        public List<DataBaseDigitalMenuItem> GetDigitalMenuItems()
        {
            return digitalMenuItems;
        }

        public DataBaseDigitalMenuItem GetDigitalMenuItemById(Guid id)
        {
            return digitalMenuItems.FirstOrDefault(item => item.Id == id) ?? new();
        }

        // Update
        public void UpdateDigitalMenuItem(DataBaseDigitalMenuItem updatedItem)
        {
            var existingItem = digitalMenuItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.DishName = updatedItem.DishName;
                existingItem.Price = updatedItem.Price;
                existingItem.IsAvailable = updatedItem.IsAvailable;
            }
        }

        // Delete
        public void RemoveDigitalMenuItem(Guid id)
        {
            var itemToRemove = digitalMenuItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                digitalMenuItems.Remove(itemToRemove);
            }
        }
    }

}
