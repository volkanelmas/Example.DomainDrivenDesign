using AutoMapper;
using Order.Application.Dtos;

namespace Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Order.Domain.AggregatesModel.OrderAggregate.User, UserDto>().ReverseMap();
            CreateMap<Order.Domain.AggregatesModel.OrderAggregate.Address, AddressDto>().ReverseMap();
            CreateMap<Order.Domain.AggregatesModel.OrderAggregate.OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Order.Domain.AggregatesModel.OrderAggregate.Order, OrderDto>().ReverseMap();
        }
    }
}
