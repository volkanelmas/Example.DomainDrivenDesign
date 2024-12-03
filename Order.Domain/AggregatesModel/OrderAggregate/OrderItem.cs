using Order.Domain.SeedWork;

namespace Order.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; }
        public decimal Total => Price * Piece;
    }
}
