using MediatR;
using Order.Application.Dtos;

namespace Order.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
