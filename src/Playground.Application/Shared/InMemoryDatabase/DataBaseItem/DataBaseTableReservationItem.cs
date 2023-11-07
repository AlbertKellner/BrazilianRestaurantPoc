namespace BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem
{
    public class DataBaseTableReservationItem
    {
        public Guid Id { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int TableId { get; set; } 
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerContact { get; set; } = string.Empty;
        public Guid OrderId { get; set; }
        public string ReservationCode { get; set; } = string.Empty;
    }
}