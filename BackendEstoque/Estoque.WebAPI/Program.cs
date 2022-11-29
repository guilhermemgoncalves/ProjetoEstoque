using Estoque.Application.Interfaces;
using Estoque.Application.Services;
using Estoque.Domain.Repository;
using Estoque.Infra.Repositories.MongoDB;
using Estoque.Infra.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<EstoqueDbSettings>(
        builder.Configuration.GetSection("EstoqueDatabase")
    );

builder.Services.AddSingleton<IToolRepository, ToolRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<ICostumerRepository, CostumerRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICostumerService, CostumerService>();
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
