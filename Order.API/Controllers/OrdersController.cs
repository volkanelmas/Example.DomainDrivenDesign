using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Command;
using Order.Application.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _mediator.Send(new GetAllOrderQuery { });
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(response);
        }
    }
}
