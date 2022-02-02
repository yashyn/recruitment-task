using Cars.Application.Commands;
using Cars.Domain.Repos;
using Cars.Infrastructure;
using Cars.Infrastructure.Repos;
using CarStore.Api.Middleware;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.AddMediatR(typeof(CreateCarCommand));

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddMvc(options => options.Filters.Add<OperationCancelledExceptionFilter>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddDbContext<CarsContext>();

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
