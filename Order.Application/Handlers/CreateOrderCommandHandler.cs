using MediatR;
using Order.Application.Command;
using Order.Application.Dtos;
using Order.Domain.AggregatesModel.OrderAggregate;
using Order.Infrastructure;

namespace Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderDto>
    {

        private readonly OrderDbContext _context;
        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<CreatedOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.Line);
            var newUser = new User(request.User.Name, request.User.Surname, request.User.Email);
            var newOrder = new Order.Domain.AggregatesModel.OrderAggregate.Order(newAddress, newUser);

            request.OrderItems.ForEach(item =>
            {
                newOrder.AddOrderItem(item.ProductName, item.Price, item.Piece);
            });

            await _context.Orders.AddAsync(newOrder);
            var result = await _context.SaveChangesAsync();
            return new CreatedOrderDto { OrderId = newOrder.Id };
        }
    }
}
