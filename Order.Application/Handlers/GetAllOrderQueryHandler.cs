using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Application.Dtos;
using Order.Application.Queries;
using Order.Infrastructure;

namespace Order.Application.Handlers
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
    {
        private readonly OrderDbContext _context;
        private IMapper _mapper;

        public GetAllOrderQueryHandler(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).ToListAsync();
            if (orders == null)
            {
                return new List<OrderDto>();
            }
            var orderDto = _mapper.Map<List<OrderDto>>(orders);
            return orderDto;
        }
    }
}
