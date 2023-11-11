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
                existingItem.ReservationDateTime = updatedItem.ReservationDateTime;
                existingItem.TableId = updatedItem.TableId;
                existingItem.CustomerName = updatedItem.CustomerName;
                existingItem.CustomerContact = updatedItem.CustomerContact;
                existingItem.OrderId = updatedItem.OrderId;
                existingItem.ReservationCode = updatedItem.ReservationCode;
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
