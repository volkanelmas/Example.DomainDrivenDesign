namespace Order.Application.Dtos
{
    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; }
    }
}
