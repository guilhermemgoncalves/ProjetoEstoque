using Estoque.Application.Interfaces;
using Estoque.Application.Services;
using Estoque.Domain.Repository;
using Estoque.Infra.Repositories.MongoDB;
using Estoque.Infra.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<EstoqueDbSettings>(
        builder.Configuration.GetSection("EstoqueDatabase")
    );

builder.Services.AddSingleton<IToolRepository, ToolRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<ICostumerRepository, CostumerRepository>();
builder.Services.AddSingleton<IConsumablesRepository, ConsumablesRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICostumerService, CostumerService>();
builder.Services.AddScoped<IConsumablesService, ConsumablesService>();
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
