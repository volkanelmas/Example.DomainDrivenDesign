using MediatR;
using Order.Application.Dtos;

namespace Order.Application.Queries
{
    public class GetAllOrderQuery : IRequest<List<OrderDto>>
    {
    }
}
