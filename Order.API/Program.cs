using Microsoft.EntityFrameworkCore;
using Order.Application.Mapping;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Sql server connectionstr tanýmlamasý ve migration ýn yer tanýmlamasý yapýlýyor.
builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    //migration neredeyse o proje ismini veriyoruz.
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("Order.Infrastructure"));
});

//Assembly istiyor. bizimki application da
//aþaðýdaki tipin baðlý olduðu assambly alýnmýþ oldu
//builder.Services.AddMediatR(typeof(Order.Application.Handlers.CreateOrderCommandHandler).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Order.Application.Handlers.CreateOrderCommandHandler).Assembly));

//auto mapper 
builder.Services.AddAutoMapper(typeof(CustomMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
