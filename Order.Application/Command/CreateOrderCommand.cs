using MediatR;
using Order.Application.Dtos;

namespace Order.Application.Command
{
    public class CreateOrderCommand : IRequest<CreatedOrderDto>
    {
        public DateTime CreatedDate { get; set; }
        public UserDto User { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
