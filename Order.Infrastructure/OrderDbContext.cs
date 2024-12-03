using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        //order.API den options okunacak
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }
        public DbSet<Order.Domain.AggregatesModel.OrderAggregate.Order> Orders { get; set; }
        public DbSet<Order.Domain.AggregatesModel.OrderAggregate.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order.Domain.AggregatesModel.OrderAggregate.OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order.Domain.AggregatesModel.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();
            modelBuilder.Entity<Order.Domain.AggregatesModel.OrderAggregate.Order>().OwnsOne(o => o.User).WithOwner();

            base.OnModelCreating(modelBuilder);
        }
    }
}
