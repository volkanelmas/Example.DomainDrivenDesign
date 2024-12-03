using Order.Domain.SeedWork;

namespace Order.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; set; }
        public Address Address { get; private set; }
        public User User { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {

        }
        public Order(Address address, User user)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            Address = address;
            User = user;
        }
        public void AddOrderItem(string ProductName, decimal Price, int Piece)
        {
            var newOrderItem = new OrderItem()
            {
                Piece = Piece,
                Price = Price,
                ProductName = ProductName
            };
            _orderItems.Add(newOrderItem);
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Total);
    }
}
