using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;

namespace Playground.Application.Shared.InMemoryDatabase
{
    public sealed class OrderInMemoryDatabase
    {
        private static readonly OrderInMemoryDatabase instance = new OrderInMemoryDatabase();
        private readonly List<DataBaseOrderItem> OrderItems;

        static OrderInMemoryDatabase()
        {
        }

        private OrderInMemoryDatabase()
        {
            OrderItems = new List<DataBaseOrderItem>();
        }

        public static OrderInMemoryDatabase Instance
        {
            get
            {
                return instance;
            }
        }

        // Create
        public void AddOrderItem(DataBaseOrderItem item)
        {
            OrderItems.Add(item);
        }

        // Read
        public List<DataBaseOrderItem> GetOrderItems()
        {
            return OrderItems;
        }

        public DataBaseOrderItem GetOrdertemById(Guid id)
        {
            return OrderItems.FirstOrDefault(item => item.Id == id) ?? new();
        }

        // Update
        public void UpdateOrderItem(DataBaseOrderItem updatedItem)
        {
            var existingItem = OrderItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.OrderName = updatedItem.OrderName;
                existingItem.Price = updatedItem.Price;
                existingItem.ChefRecommendation = updatedItem.ChefRecommendation;
            }
        }

        // Delete
        public void RemoveOrderItem(Guid id)
        {
            var itemToRemove = OrderItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                OrderItems.Remove(itemToRemove);
            }
        }
    }

}
