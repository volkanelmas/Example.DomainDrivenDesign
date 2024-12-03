using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Application.Dtos;
using Order.Application.Queries;
using Order.Infrastructure;

namespace Order.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly OrderDbContext _context;
        private IMapper _mapper;

        public GetOrderByIdQueryHandler(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(x => x.OrderItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (order == null)
            {
                return new OrderDto();
            }
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
    }
}
